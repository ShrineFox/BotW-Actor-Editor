using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotWPhysicsReplacer
{
    public partial class BotWActorEditor : Form
    {
        public string originalActorPath = "";
        public List<string> originalActors = new List<string>();
        public List<string> originalActorDirs = new List<string>();

        public string replaceActorPath = "";
        public string replaceDirectory = "";
        public string pythonPath = "";

        public BotWActorEditor()
        {
            InitializeComponent();
#if DEBUG
            originalActorPath = @"C:\Users\ryans\Desktop\Mipha\Change";
            replaceActorPath = @"C:\Users\ryans\Desktop\Mipha\Physics\Dm_Npc_Zora_Hero.sbactorpack";
#endif
            if (File.Exists(originalActorPath) || Directory.Exists(originalActorPath))
            {
                lbl_OriginalActor.Text = Path.GetFileNameWithoutExtension(originalActorPath);
                btn_RebuildActor.Enabled = true;
            }
            if (File.Exists(replaceActorPath))
            {
                lbl_ReplaceActor.Text = Path.GetFileNameWithoutExtension(replaceActorPath);
                chkBox_ReplacePhys.Enabled = true;
                chkBox_ReplacePhys.Checked = true;
            }
                

        }

        private void Original_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void Replace_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void Original_DragDrop(object sender, DragEventArgs e)
        {
            var data = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (File.Exists(data[0]) && Path.GetExtension(data[0]).ToLower() == ".sbactorpack" || Directory.Exists(data[0]))
            {
                originalActorPath = data[0];
                lbl_OriginalActor.Text = Path.GetFileNameWithoutExtension(data[0]);
                if (lbl_OriginalActor.Text != "")
                    btn_RebuildActor.Enabled = true;
            }
        }

        private void Replace_DragDrop(object sender, DragEventArgs e)
        {
            var data = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (File.Exists(data[0]) && Path.GetExtension(data[0]).ToLower() == ".sbactorpack")
            {
                replaceActorPath = data[0];
                lbl_ReplaceActor.Text = Path.GetFileNameWithoutExtension(data[0]);
                if (File.Exists(replaceActorPath))
                {
                    lbl_ReplaceActor.Text = Path.GetFileNameWithoutExtension(replaceActorPath);
                    chkBox_ReplacePhys.Enabled = true;
                    chkBox_ReplacePhys.Checked = true;
                }
                if (File.Exists(originalActorPath))
                    btn_RebuildActor.Enabled = true;
            }
        }

        private void Rebuild_Click(object sender, EventArgs e)
        {
            //Clear log, actor list and check python dependencies
            txtBox_Output.Text = "";
            originalActors = new List<string>();
            originalActorDirs = new List<string>();
            if (PythonCheck())
            {
                //Extract SARC 1 to folder
                if (originalActorPath != "")
                {
                    //Check if SARC 1 path is a directory or single .sbactorpack
                    FileAttributes attr = File.GetAttributes(originalActorPath);
                    if (attr.HasFlag(FileAttributes.Directory))
                        foreach (var file in Directory.GetFiles(originalActorPath, "*.sbactorpack", SearchOption.TopDirectoryOnly))
                            originalActors.Add(file);
                    else if (Path.GetExtension(originalActorPath) == ".sbactorpack")
                        originalActors.Add(originalActorPath);

                    //Extract each original SARC's contents to own folder
                    foreach (var actor in originalActors)
                    {
                        Log($"Extracting {Path.GetFileName(actor)}...");
                        RunCMD($"{pythonPath} -m sarc extract {actor}");
                        originalActorDirs.Add(Path.Combine(Path.GetDirectoryName(actor), Path.GetFileNameWithoutExtension(actor)));
                    }
                }

                //Extract SARC 2 to folder (optional)
                if (chkBox_ReplacePhys.Checked)
                {
                    Log($"Extracting {Path.GetFileName(replaceActorPath)}...");
                    RunCMD($"{pythonPath} -m sarc extract {replaceActorPath}");
                    replaceDirectory = Path.Combine(Path.GetDirectoryName(replaceActorPath), Path.GetFileNameWithoutExtension(replaceActorPath));
                }

                //Wait for SARCs to be extracted
                while (!Directory.Exists(originalActorDirs.LastOrDefault())) { }
                Thread.Sleep(200);
                Log($"SARC extraction complete.");

                //If SARC 2 is extracted...
                if (chkBox_ReplacePhys.Checked)
                {
                    //Replace PhysicsUser value in SARC 1 .bxml w/ SARC 2 PhysicsUser
                    ChangeSARCValue("bxml", new List<Tuple<string, string>>() { new Tuple<string, string>("PhysicsUser", Path.GetFileNameWithoutExtension(replaceActorPath))});
                    //Delete .bphysics in SARC 1, Add .bphysics from SARC 2
                    SwapSARCFiles("bphysics");
                    //Delete Cloth .hkcl in SARC 1, Add Cloth .hkcl from SARC 2
                    SwapSARCFiles("hkcl");
                    //Delete Support Bone .bphyssb in SARC 1, Add Support Bone .bphyssb from SARC 2
                    SwapSARCFiles("bphyssb");
                }

                //Edit AAMP files if options are checked
                var bgparamlistChanges = new List<Tuple<string, string>>();
                if (chkBox_Waterfall.Checked)
                    bgparamlistChanges.Add(new Tuple<string, string>("EnableClimbWaterfall", "true"));
                if (chkBox_SpinAttack.Checked)
                    bgparamlistChanges.Add(new Tuple<string, string>("EnableSpinAttack", "true"));
                if (bgparamlistChanges.Count > 0)
                    ChangeSARCValue("bgparamlist", bgparamlistChanges);

                //Resave and Output as Switch/Wii U .sbactorpacks
                SaveSARC();

                //Delete temporary folders if SARC is finished saving
                if (!chkBox_KeepSARC.Checked)
                {
                    Log("Deleting temporary folders...");
                    foreach (var folder in originalActorDirs)
                        if (Directory.Exists(folder))
                            Directory.Delete(folder, true);
                    if (Directory.Exists(replaceDirectory))
                        Directory.Delete(replaceDirectory, true);
                }

                Log("Done!");
            }
        }

        private void SaveSARC()
        {
            //Create fresh directories for Wii U/Switch output
            string wiiUDir = Path.Combine(Path.GetDirectoryName(originalActorDirs[0]), "Wii U");
            string switchDir = Path.Combine(Path.GetDirectoryName(originalActorDirs[0]), "Switch");
            if (Directory.Exists(wiiUDir))
                Directory.Delete(wiiUDir, true);
            if (Directory.Exists(switchDir))
                Directory.Delete(switchDir, true);
            Directory.CreateDirectory(wiiUDir);
            Directory.CreateDirectory(switchDir);

            //Wait for new Switch folder to exist
            while (!Directory.Exists(switchDir)) { }

            //Wait for each extracted SARC folder to exist and repack
            Log("Saving new .sbactorpack files...");
            foreach (var dir in originalActorDirs)
            {
                RunCMD($"{pythonPath.Replace("python.exe", "Scripts\\sarc.exe")} create --be \"{dir}\" \"{Path.Combine(wiiUDir, Path.GetFileNameWithoutExtension(dir) + ".sbactorpack")}\"");
                RunCMD($"{pythonPath.Replace("python.exe", "Scripts\\sarc.exe")} create \"{dir}\" \"{Path.Combine(switchDir, Path.GetFileNameWithoutExtension(dir) + ".sbactorpack")}\"");
                using (WaitForFile(Path.Combine(wiiUDir, Path.GetFileNameWithoutExtension(dir) + ".sbactorpack"), FileMode.Open, FileAccess.ReadWrite, FileShare.None)) { };
                using (WaitForFile(Path.Combine(switchDir, Path.GetFileNameWithoutExtension(dir) + ".sbactorpack"), FileMode.Open, FileAccess.ReadWrite, FileShare.None)) { };
            }
        }

        private void SwapSARCFiles(string extension)
        {
            //Wait for extracted SARC 2 directory
            while(!Directory.Exists(replaceDirectory)) { }

            foreach (var dir in originalActorDirs)
                foreach (var aampFile in Directory.GetFiles(dir, $"*.{extension}", SearchOption.AllDirectories))
                    foreach (var aampFile2 in Directory.GetFiles(replaceDirectory, $"*.{extension}", SearchOption.AllDirectories))
                    {
                        //Delete original file and/or previous replacement
                        var newAampPath = Path.Combine(Path.GetDirectoryName(aampFile), Path.GetFileName(aampFile2));
                        if (File.Exists(aampFile))
                            File.Delete(aampFile);
                        if (File.Exists(newAampPath))
                            File.Delete(newAampPath);

                        //Move replacement file to original file's location
                        File.Copy(aampFile2, newAampPath);
                        Log($"Replacing {Path.GetFileName(aampFile)} with {Path.GetFileName(aampFile2)} in {Path.GetFileName(dir)}...");                    
                    }
        }

        private void ChangeSARCValue(string extension, List<Tuple<string, string>> changes)
        {
            foreach (var dir in originalActorDirs)
            {
                foreach (var aampFile in Directory.GetFiles(dir, $"*.{extension}", SearchOption.AllDirectories))
                {
                    //Convert bxml to YML for editing
                    string ymlFile = Path.Combine(Path.GetDirectoryName(aampFile), Path.GetFileName(aampFile)) + ".yml";
                    RunCMD($"{pythonPath.Replace("python.exe", "Scripts\\aamp_to_yml.exe")} {aampFile} {ymlFile}");

                    //Wait for YML file to be created
                    using (WaitForFile(ymlFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) { };

                    //Replace each matching line with changed value
                    string[] fileText = File.ReadAllLines(ymlFile);
                    foreach (var change in changes)
                    {
                        Log($"Setting {change.Item1} to {change.Item2} in {Path.GetFileName(dir)}...");
                        for (int i = 0; i < fileText.Count(); i++)
                            if (fileText[i].Contains($"{change.Item1}: "))
                                fileText[i] = $"{change.Item1}: {change.Item2}".PadLeft(fileText[i].IndexOf(change.Item1), ' ');
                    }

                    //Overwrite YML with changes
                    File.WriteAllLines(ymlFile, fileText);

                    //Wait for YML file to be updated
                    using (WaitForFile(ymlFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) { };

                    //Create new AAMP from YML, overwriting original
                    RunCMD($"{pythonPath.Replace("python.exe", "Scripts\\yml_to_aamp.exe")} {ymlFile} {aampFile}");

                    //Wait for AAMP file to be overwritten
                    using (WaitForFile(aampFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) { };

                    //Move YML file to new directory for reference or delete
                    string newDir = Path.Combine(Path.GetDirectoryName(dir), $"{Path.GetFileNameWithoutExtension(dir)}_Edited_YML");
                    string newFile = Path.Combine(newDir, Path.GetFileName(ymlFile));
                    if (chkBox_KeepYML.Checked)
                    {
                        Directory.CreateDirectory(newDir);
                        if (File.Exists(newFile))
                            File.Delete(newFile);
                        File.Move(ymlFile, newFile);
                    }
                    else
                        File.Delete(ymlFile);
                }
            }
        }

        private string GetPythonPath(string requiredVersion = "", string maxVersion = "")
        {
            string[] possiblePythonLocations = new string[3] {
                @"HKLM\SOFTWARE\Python\PythonCore\",
                @"HKCU\SOFTWARE\Python\PythonCore\",
                @"HKLM\SOFTWARE\Wow6432Node\Python\PythonCore\"
            };

            //Version number, install path
            Dictionary<string, string> pythonLocations = new Dictionary<string, string>();

            foreach (string possibleLocation in possiblePythonLocations)
            {
                try
                {
                    string regKey = possibleLocation.Substring(0, 4), actualPath = possibleLocation.Substring(5);
                    RegistryKey theKey = (regKey == "HKLM" ? Registry.LocalMachine : Registry.CurrentUser);
                    RegistryKey theValue = theKey.OpenSubKey(actualPath);

                    foreach (var v in theValue.GetSubKeyNames())
                    {
                        RegistryKey productKey = theValue.OpenSubKey(v);
                        if (productKey != null)
                        {
                            try
                            {
                                string pythonExePath = productKey.OpenSubKey("InstallPath").GetValue("ExecutablePath").ToString();
                                if (pythonExePath != null && pythonExePath != "")
                                {
                                    //MessageBox.Show("Got python version " + v + " at path: " + pythonExePath);
                                    pythonLocations.Add(v.ToString(), pythonExePath);
                                }
                            }
                            catch
                            {
                                
                            }
                        }
                    }
                }
                catch
                {
                    //MessageBox.Show("Null value opening SubKey of " + possibleLocation);
                }
            }

            if (pythonLocations.Count > 0)
            {
                System.Version desiredVersion = new System.Version(requiredVersion == "" ? "0.0.1" : requiredVersion),
                    maxPVersion = new System.Version(maxVersion == "" ? "999.999.999" : maxVersion);

                string highestVersion = "", highestVersionPath = "";

                foreach (KeyValuePair<string, string> pVersion in pythonLocations)
                {
                    //Require 64 bit
                    if (!pVersion.Value.Contains("-32"))
                    {
                        int index = pVersion.Key.IndexOf("-"); //For x-32 and x-64 in version numbers
                        string formattedVersion = index > 0 ? pVersion.Key.Substring(0, index) : pVersion.Key;

                        System.Version thisVersion = new System.Version(formattedVersion);
                        int comparison = desiredVersion.CompareTo(thisVersion),
                            maxComparison = maxPVersion.CompareTo(thisVersion);

                        if (comparison <= 0)
                        {
                            //Version is greater or equal
                            if (maxComparison >= 0)
                            {
                                desiredVersion = thisVersion;

                                highestVersion = pVersion.Key;
                                highestVersionPath = pVersion.Value;
                            }
                            else
                            {
                                //Console.WriteLine("Version is too high; " + maxComparison.ToString());
                            }
                        }
                        else
                        {
                            //Console.WriteLine("Version (" + pVersion.Key + ") is not within the spectrum.");
                        }
                    }
                }

                //Console.WriteLine(highestVersion);
                //Console.WriteLine(highestVersionPath);
                return highestVersionPath;
            }

            return "";
        }

        private bool PythonCheck()
        {
            //Check if python is installed, if so get python path
            pythonPath = GetPythonPath("3.6.1");
            if (pythonPath != "")
                Log("Python install detected: " + pythonPath);
            else
            {
                Log("Couldn't detect a 64-bit Python 3.6 installation!");
                return false;
            }
                

            //Check if sarc, aamp and byml scripts are installed
            if (pythonPath != "")
            {
                string[] scripts = new string[] { "sarc", "aamp_to_yml"};
                foreach (var script in scripts)
                {
                    var exePath = Path.Combine(Path.GetDirectoryName(pythonPath), $"Scripts\\{script}.exe");
                    if (!File.Exists(exePath))
                    {
                        Log($"Could not find Python script \"{script}\" at {exePath}");
                        Log($"Attempting to install \"{script}\"...");
                        RunCMD($"{pythonPath} -m pip install {script.Split('_').First()}", false);
                        Log($"\"{script}\" installed, try rebuilding sbactorpack again.");
                        return false;
                    }
                    else
                    {
                        Log($"Found Python script \"{script}\" successfully!");
                    }
                }
            }
            return true;
        }

        private void RunCMD(string args, bool hidden = true)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "cmd";
            start.Arguments = $"/K {args}";
            start.UseShellExecute = true;
            start.RedirectStandardOutput = false;
            if (hidden)
                start.WindowStyle = ProcessWindowStyle.Hidden;
            using (Process process = Process.Start(start))
            {

            }
        }

        private void Log(string text)
        {
            txtBox_Output.Text += $"{text}\n";
            txtBox_Output.SelectionStart = txtBox_Output.Text.Length;
            txtBox_Output.ScrollToCaret();
        }

        FileStream WaitForFile(string fullPath, FileMode mode, FileAccess access, FileShare share)
        {
            for (int numTries = 0; numTries < 10; numTries++)
            {
                FileStream fs = null;
                try
                {
                    fs = new FileStream(fullPath, mode, access, share);
                    return fs;
                }
                catch (IOException)
                {
                    if (fs != null)
                    {
                        fs.Dispose();
                    }
                    Thread.Sleep(50);
                }
            }

            return null;
        }

        private void PhysicsUser_Unchecked(object sender, EventArgs e)
        {
            if (!chkBox_ReplacePhys.Checked)
            {
                replaceActorPath = "";
                lbl_ReplaceActor.Text = "";
                chkBox_ReplacePhys.Enabled = false;
            }
        }
    }
}
