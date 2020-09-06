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
        public string pythonPath = "";
        public int sleepTime = 50;

        public string sourceActorPath = "";
        public string targetActorPath = "";
        public string targetActorDir = "";

        public List<string> sourceActors = new List<string>();
        public List<string> sourceActorDirs = new List<string>();

        string switchDir = "";
        string wiiUDir = "";

        public BotWActorEditor()
        {
            InitializeComponent();
            if (File.Exists(sourceActorPath) || Directory.Exists(sourceActorPath))
            {
                lbl_SourceActor.Text = Path.GetFileNameWithoutExtension(sourceActorPath);
                btn_RebuildActor.Enabled = true;
            }
            if (File.Exists(targetActorPath))
                lbl_TargetActor.Text = Path.GetFileNameWithoutExtension(targetActorPath);
        }

        private void Rebuild_Click(object sender, EventArgs e)
        {
            //Clear log, actor list and check python dependencies
            txtBox_Output.Text = "";
            sourceActors = new List<string>();
            sourceActorDirs = new List<string>();
            sleepTime = Convert.ToInt32(numUpDwn_WaitTime.Value);

            //If Python scripts are installed...
            if (PythonCheck())
            {
                //Check if Source SARC path is a directory or single .sbactorpack
                FileAttributes attr = File.GetAttributes(sourceActorPath);
                if (attr.HasFlag(FileAttributes.Directory))
                    foreach (var file in Directory.GetFiles(sourceActorPath, "*.sbactorpack", SearchOption.TopDirectoryOnly))
                        sourceActors.Add(file);
                else if (Path.GetExtension(sourceActorPath) == ".sbactorpack")
                    sourceActors.Add(sourceActorPath);

                //Extract Target SARC to folder (optional)
                if (File.Exists(targetActorPath))
                    targetActorDir = ExtractSARC(targetActorPath);

                //Create folders for Switch/WiiU
                if (sourceActors.Count > 0)
                {
                    wiiUDir = Path.Combine(Path.GetDirectoryName(Path.Combine(Path.GetDirectoryName(sourceActors[0]), Path.GetFileNameWithoutExtension(sourceActors[0]))), "Wii U");
                    switchDir = Path.Combine(Path.GetDirectoryName(Path.Combine(Path.GetDirectoryName(sourceActors[0]), Path.GetFileNameWithoutExtension(sourceActors[0]))), "Switch");
                    if (Directory.Exists(wiiUDir))
                        Directory.Delete(wiiUDir, true);
                    if (Directory.Exists(switchDir))
                        Directory.Delete(switchDir, true);
                    Directory.CreateDirectory(wiiUDir);
                    Directory.CreateDirectory(switchDir);
                }

                //Process each Source SARC
                foreach (var actor in sourceActors)
                {
                    //Extract Source SARC contents
                    string sourceActorDir = ExtractSARC(actor);
                    sourceActorDirs.Add(sourceActorDir);

                    //If Target SARC is extracted...
                    if (Directory.Exists(targetActorDir))
                    {
                        string unitName = GetAAMPValue(sourceActorDir, "bmodellist", "UnitName: "); //Armor_001_Head_A
                        string actorName = Path.GetFileNameWithoutExtension(actor); //Armor_001_Head
                        string bfresFolderName = GetAAMPValue(sourceActorDir, "bmodellist", "Folder: "); //Armor_001

                        //If BFRES Name is obtainable...
                        if (bfresFolderName != "")
                        {
                            //Replace Physics reference strings
                            ChangeSARCValue(sourceActorDir, "bphysics", new List<Tuple<string, string>>() { new Tuple<string, string>("SupportBone", $"!obj {{support_bone_setup_file_path: !str256 {bfresFolderName}/{actorName}.bphysbb}}"), new Tuple<string, string>("ClothHeader", $"!obj {{cloth_setup_file_path: !str256 {bfresFolderName}/{actorName}.hkcl,") });
                            //Delete .bphysics in Source SARC, Add .bphysics from Target SARC
                            SwapSARCFiles(sourceActorDir, "bphysics", unitName, "");
                            //Delete Cloth .hkcl in Source SARC, Add Cloth .hkcl from Target SARC
                            SwapSARCFiles(sourceActorDir, "hkcl", unitName, bfresFolderName);
                            //Delete Support Bone .bphyssb in Source SARC, Add Support Bone .bphyssb from Target SARC
                            SwapSARCFiles(sourceActorDir, "bphyssb", unitName, bfresFolderName);
                        }
                        else
                            Log("Could not obtain BFRES Folder Name. Skipping physics...");
                    }

                    //Edit AAMP files if options are checked
                    var bgparamlistChanges = new List<Tuple<string, string>>();
                    if (chkBox_Waterfall.Checked)
                        bgparamlistChanges.Add(new Tuple<string, string>("EnableClimbWaterfall", "true"));
                    if (chkBox_SpinAttack.Checked)
                        bgparamlistChanges.Add(new Tuple<string, string>("EnableSpinAttack", "true"));
                    if (bgparamlistChanges.Count > 0)
                        ChangeSARCValue(sourceActorDir, "bgparamlist", bgparamlistChanges);

                    //Output new Switch/Wii U .sbactorpacks
                    SaveSARC(sourceActorDir);
                }

                //Delete temporary folders if SARC is finished saving
                if (!chkBox_KeepSARC.Checked)
                {
                    Log("Deleting temporary folders...");
                    foreach (var folder in sourceActorDirs)
                        if (Directory.Exists(folder))
                            Directory.Delete(folder, true);
                    if (Directory.Exists(targetActorDir))
                        Directory.Delete(targetActorDir, true);
                }

                Log("Done!");
            }
        }

        /*
         *       SARC MANAGEMENT
         */

        private string ExtractSARC(string path)
        {
            string extractedSARCDir = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path));
            //Extract SARC
            Log($"Extracting {Path.GetFileName(path)}...");
            RunCMD($"{pythonPath} -m sarc extract \"{path}\"");

            //Wait for SARC to be fully extracted
            WaitForPopulatedFolder(extractedSARCDir);

            //Copy Extracted SARC Dir for reference (if it's a Source SARC)
            if (chkBox_KeepOriginalSARC.Checked && Path.GetFileName(extractedSARCDir) != Path.GetFileNameWithoutExtension(targetActorPath))
                CopyFolder(extractedSARCDir, extractedSARCDir + "_Unmodified");

            return extractedSARCDir;
        }

        private string GetAAMPValue(string sarcDir, string extension, string key)
        {
            string value = "";

            foreach (var aampFile in Directory.GetFiles(sarcDir, $"*.{extension}", SearchOption.AllDirectories))
            {
                //Convert AAMP to YML for reading
                string ymlFile = Path.Combine(Path.GetDirectoryName(aampFile), Path.GetFileName(aampFile)) + ".yml";
                RunCMD($"{pythonPath} -m aamp \"{aampFile}\" \"{ymlFile}\"");

                //Wait for YML file to be created
                using (WaitForFile(ymlFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) { };

                //Get Folder string
                string[] fileText = File.ReadAllLines(ymlFile);
                foreach (var line in fileText)
                    if (line.Contains(key))
                        value = line.Remove(0, EndIndexOf(line, "!str64")).Split(' ')[1].Replace("}", "").Replace(",", "").Trim();

                //Delete YML File
                using (WaitForFile(ymlFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) { };
                File.Delete(ymlFile);
            }

            return value;
        }

        private void SaveSARC(string sarcPath)
        {
            Log("Saving new .sbactorpack files...");

            //Wait for new Switch folder to exist
            while (!Directory.Exists(switchDir)) { Thread.Sleep(sleepTime); }

            //Wait for each extracted SARC folder to exist and repack
            foreach (var dir in sourceActorDirs)
            {
                while (!Directory.Exists(dir)) { Thread.Sleep(sleepTime); }
                RunCMD($"{pythonPath} -m sarc create --be \"{dir}\" \"{Path.Combine(wiiUDir, Path.GetFileNameWithoutExtension(dir) + ".sbactorpack")}\"");
                RunCMD($"{pythonPath} -m sarc create \"{dir}\" \"{Path.Combine(switchDir, Path.GetFileNameWithoutExtension(dir) + ".sbactorpack")}\"");
                using (WaitForFile(Path.Combine(wiiUDir, Path.GetFileNameWithoutExtension(dir) + ".sbactorpack"), FileMode.Open, FileAccess.ReadWrite, FileShare.None)) { };
                using (WaitForFile(Path.Combine(switchDir, Path.GetFileNameWithoutExtension(dir) + ".sbactorpack"), FileMode.Open, FileAccess.ReadWrite, FileShare.None)) { };
                if (!chkBox_CMD.Checked)
                    KillCMDProcesses();
            }
        }

        private void SwapSARCFiles(string dir, string extension, string fileName, string folderName)
        {
            //For each file in Target SARC with a matching extension...
            foreach (var aampFile2 in Directory.GetFiles(targetActorDir, $"*.{extension}", SearchOption.AllDirectories))
            {
                //Delete files matching extension in Source SARC
                foreach (var aampFile in Directory.GetFiles(dir, $"*.{extension}", SearchOption.AllDirectories))
                    if (File.Exists(aampFile))
                        File.Delete(aampFile);

                //Make path for new file
                string destFile = dir + Path.GetDirectoryName(aampFile2).Remove(0, EndIndexOf(Path.GetDirectoryName(aampFile2), Path.GetFileName(targetActorDir)));
                if (extension == "bphyssb" || extension == "hkcl")
                    destFile = Path.Combine(Path.GetDirectoryName(destFile), folderName);
                destFile = Path.Combine(destFile, fileName) + $".{extension}";

                //Delete existing destination file
                if (File.Exists(destFile))
                    File.Delete(destFile);

                //Copy replacement file to new location
                Directory.CreateDirectory(Path.GetDirectoryName(destFile));
                File.Copy(aampFile2, destFile);
                Log($"Copying {Path.GetFileName(aampFile2)} to {Path.GetFileName(dir)} as {Path.GetFileName(destFile)}...");                    
            }
        }

        private void ChangeSARCValue(string dir, string extension, List<Tuple<string, string>> changes)
        {
            foreach (var aampFile in Directory.GetFiles(dir, $"*.{extension}", SearchOption.AllDirectories))
            {
                //Convert AAMP to YML for editing
                string ymlFile = Path.Combine(Path.GetDirectoryName(aampFile), Path.GetFileName(aampFile)) + ".yml";
                RunCMD($"{pythonPath} -m aamp \"{aampFile}\" \"{ymlFile}\"");

                //Wait for YML file to be created
                using (WaitForFile(ymlFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) { };
                Thread.Sleep(sleepTime);

                //Replace each matching line with changed value
                string[] fileText = File.ReadAllLines(ymlFile);
                foreach (var change in changes)
                {
                    for (int i = 0; i < fileText.Count(); i++)
                        if (fileText[i].Contains($"{change.Item1}: "))
                        {
                            string newText = "";
                            int padAmnt = fileText[i].TakeWhile(Char.IsWhiteSpace).Count();
                            Log($"Setting {change.Item1} to {change.Item2} in {Path.GetFileName(dir)}...");
                                newText = $"{change.Item1}: {change.Item2}";
                            fileText[i] = newText.PadLeft(padAmnt + newText.Length);
                        }
                }

                //Overwrite YML with changes
                File.WriteAllLines(ymlFile, fileText);

                //Wait for YML file to be updated
                using (WaitForFile(ymlFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) { };
                Thread.Sleep(sleepTime);

                //Create new AAMP from YML, overwriting original
                RunCMD($"{pythonPath} -m aamp \"{ymlFile}\" \"{aampFile}\"");

                //Wait for AAMP file to be overwritten
                using (WaitForFile(aampFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) { };
                Thread.Sleep(sleepTime);

                //Move YML file to new directory for reference or delete
                using (WaitForFile(ymlFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) { };
                if (sleepTime < 200)
                    Thread.Sleep(200);
                else
                    Thread.Sleep(sleepTime);
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

        /*
         *       UTILITIES
         */

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
                        Log($"Found Python script \"{script}\" successfully!");
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
            if (hidden && !chkBox_CMD.Checked)
            {
                start.Arguments.Replace("/K", "/C");
                start.WindowStyle = ProcessWindowStyle.Hidden;
            }
            using (Process process = Process.Start(start)) { }
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
                    Thread.Sleep(sleepTime);
                }
            }

            return null;
        }

        static public void CopyFolder(string sourceFolder, string destFolder)
        {
            foreach (string dirPath in Directory.GetDirectories(sourceFolder, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(sourceFolder, destFolder));

            foreach (string newPath in Directory.GetFiles(sourceFolder, "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(sourceFolder, destFolder), true);
        }

        private void WaitForPopulatedFolder(string dir)
        {
            bool populated = false;
            while (!Directory.Exists(dir)) { }
            Thread.Sleep(sleepTime);

            while (!populated)
            {
                populated = true;
                foreach (var subdir in Directory.GetDirectories(dir, "*", SearchOption.AllDirectories))
                    if (Directory.GetDirectories(subdir).Count() == 0 && Directory.GetFiles(subdir).Count() == 0)
                        populated = false;
                Thread.Sleep(sleepTime);
            }
        }

        public static int EndIndexOf(string source, string value)
        {
            int index = source.IndexOf(value);
            if (index >= 0)
            {
                index += value.Length;
            }

            return index;
        }

        private void KillCMDProcesses()
        {
            foreach (var process in Process.GetProcessesByName("cmd"))
                process.Kill();
        }

        /*
         *       FORM CONTROLS
         */

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
                sourceActorPath = data[0];
                lbl_SourceActor.Text = Path.GetFileNameWithoutExtension(data[0]);
                if (File.Exists(sourceActorPath) || Directory.Exists(sourceActorPath))
                    btn_RebuildActor.Enabled = true;
                else
                    btn_RebuildActor.Enabled = false;
            }
        }

        private void Replace_DragDrop(object sender, DragEventArgs e)
        {
            var data = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (File.Exists(data[0]) && Path.GetExtension(data[0]).ToLower() == ".sbactorpack")
            {
                targetActorPath = data[0];
                lbl_TargetActor.Text = Path.GetFileNameWithoutExtension(data[0]);
                if (File.Exists(targetActorPath))
                    lbl_TargetActor.Text = Path.GetFileNameWithoutExtension(targetActorPath);
                if (!File.Exists(targetActorPath))
                    btn_RebuildActor.Enabled = false;
            }
        }

        private void KillCMD_Click(object sender, EventArgs e)
        {
            KillCMDProcesses();
        }
    }
}
