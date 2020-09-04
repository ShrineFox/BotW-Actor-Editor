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
    public partial class BotwPhysicsReplacerForm : Form
    {
        public string originalActorPath = "";
        public string replaceActorPath = "";
        public string originalDirectory = "";
        public string replaceDirectory = "";
        public string pythonPath = "";
        public string physicsUser = "";

        public BotwPhysicsReplacerForm()
        {
            InitializeComponent();
#if DEBUG
            //pythonPath = @"C:\Users\Ryan\AppData\Local\Programs\Python\Python38\python.exe";
            originalActorPath = @"C:\Users\ryans\Desktop\Mipha\Armor_001_Lower.sbactorpack";
            replaceActorPath = @"C:\Users\ryans\Desktop\Mipha\Dm_Npc_Zora_Hero.sbactorpack";
#endif
            if (File.Exists(originalActorPath) && File.Exists(replaceActorPath))
            {
                lbl_OriginalActor.Text = Path.GetFileNameWithoutExtension(originalActorPath);
                lbl_ReplaceActor.Text = Path.GetFileNameWithoutExtension(replaceActorPath);
                btn_RebuildActor.Enabled = true;
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
            if (File.Exists(data[0]) && Path.GetExtension(data[0]).ToLower() == ".sbactorpack")
            {
                originalActorPath = data[0];
                lbl_OriginalActor.Text = Path.GetFileNameWithoutExtension(data[0]);
                if (lbl_OriginalActor.Text != "" && lbl_ReplaceActor.Text != "")
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
                if (lbl_OriginalActor.Text != "" && lbl_ReplaceActor.Text != "")
                    btn_RebuildActor.Enabled = true;
            }
        }

        private void Rebuild_Click(object sender, EventArgs e)
        {
            //Clear log and check python dependencies
            txtBox_Output.Text = "";
            if (PythonCheck())
            {
                //Extract 1st sarc to folder
                Log($"Extracting {Path.GetFileName(originalActorPath)}...");
                RunCMD($"{pythonPath} -m sarc extract {originalActorPath}");
                //Extract 2nd sarc to folder
                Log($"Extracting {Path.GetFileName(replaceActorPath)}...");
                RunCMD($"{pythonPath} -m sarc extract {replaceActorPath}");

                //Wait for SARCs to be extracted
                originalDirectory = Path.Combine(Path.GetDirectoryName(originalActorPath), Path.GetFileNameWithoutExtension(originalActorPath));
                replaceDirectory = Path.Combine(Path.GetDirectoryName(replaceActorPath), Path.GetFileNameWithoutExtension(replaceActorPath));
                while (!Directory.Exists(replaceDirectory)) { }
                Log($"Done extracting SARCs.");

                //If SARCs both extracted successfully...
                if (VerifySARC())
                {
                    //Replace PhysicsUser value in SARC 1 .bxml w/ SARC 2 PhysicsUser
                    ChangeSARCValue("bxml", "PhysicsUser", $"{Path.GetFileNameWithoutExtension(replaceActorPath)}");

                    //Delete .bphysics in SARC 1, Add .bphysics from SARC 2
                    SwapSARCFiles("bphysics");
                    //Delete Cloth .hkcl in SARC 1, Add Cloth .hkcl from SARC 2
                    SwapSARCFiles("hkcl");
                    //Delete Support Bone .bphyssb in SARC 1, Add Support Bone .bphyssb from SARC 2
                    SwapSARCFiles("bphyssb");

                    //Edit baiprog if checked
                    if (chkBox_Waterfall.Checked)
                    {
                        ChangeSARCValue("bgparamlist", "EnableClimbWaterfall", "true");
                        ChangeSARCValue("bgparamlist", "EnableSpinAttack", "true");
                    }

                    //Resave and Output as Switch/Wii U .sbactorpacks
                    SaveSARC();

                    //Delete temporary folders
                    Log("Deleting temporary folders...");
                    if (Directory.Exists(originalDirectory))
                        Directory.Delete(originalDirectory, true);
                    if (Directory.Exists(replaceDirectory))
                        Directory.Delete(replaceDirectory, true);

                    Log("Done!");
                }
            }
        }

        private void SaveSARC()
        {
            string wiiUDir = Path.Combine(Path.GetDirectoryName(originalDirectory), "Wii U");
            string switchDir = Path.Combine(Path.GetDirectoryName(originalDirectory), "Switch");
            if (Directory.Exists(wiiUDir))
                Directory.Delete(wiiUDir, true);
            if (Directory.Exists(switchDir))
                Directory.Delete(switchDir, true);

            Thread.Sleep(500);

            Directory.CreateDirectory(wiiUDir);
            Directory.CreateDirectory(switchDir);

            while (!Directory.Exists(switchDir)) { }

            Log("Saving Wii U .sbactorpack");
            RunCMD($"{pythonPath.Replace("python.exe", "Scripts\\sarc.exe")} create --be \"{originalDirectory}\" \"{Path.Combine(wiiUDir, Path.GetFileName(originalActorPath))}\"");
            Log("Saving Switch .sbactorpack");
            RunCMD($"{pythonPath.Replace("python.exe", "Scripts\\sarc.exe")} create \"{originalDirectory}\" \"{Path.Combine(switchDir, Path.GetFileName(originalActorPath))}\"");
        }

        private bool VerifySARC()
        {
            if (!Directory.Exists(originalDirectory))
            {
                Log($"Failed to extract {Path.GetFileName(originalDirectory)}.");
                return false;
            }
            else if (!Directory.Exists(replaceDirectory))
            {
                Log($"Failed to extract {Path.GetFileName(originalDirectory)}.");
                return false;
            }
            return true;
        }

        private void SwapSARCFiles(string extension)
        {
            string sarc2AAMPPath = "";

            foreach (var aampFile in Directory.GetFiles(originalDirectory, $"*.{extension}", SearchOption.AllDirectories))
            {
                foreach (var aampFile2 in Directory.GetFiles(replaceDirectory, $"*.{extension}", SearchOption.AllDirectories))
                    sarc2AAMPPath = aampFile2;
                File.Delete(aampFile);
                Log($"Replacing {Path.GetFileName(aampFile)} with {Path.GetFileName(sarc2AAMPPath)}...");
                if (File.Exists(Path.Combine(Path.GetDirectoryName(aampFile), Path.GetFileName(sarc2AAMPPath))))
                    File.Delete(Path.Combine(Path.GetDirectoryName(aampFile), Path.GetFileName(sarc2AAMPPath)));
                File.Copy(sarc2AAMPPath, Path.Combine(Path.GetDirectoryName(aampFile), Path.GetFileName(sarc2AAMPPath)));
            }
        }

        private void ChangeSARCValue(string extension = "aamp", string oldLine = "", string newLine = "")
        {
            foreach (var aampFile in Directory.GetFiles(originalDirectory, $"*.{extension}", SearchOption.AllDirectories))
            {
                //Convert bxml to YML for editing
                string ymlFile = Path.Combine(Path.GetDirectoryName(aampFile), Path.GetFileName(aampFile)) + ".yml";
                RunCMD($"{pythonPath.Replace("python.exe", "Scripts\\aamp_to_yml.exe")} {aampFile} {ymlFile}");

                //Wait for YML file to be created
                while(!File.Exists(ymlFile)) { }
                Thread.Sleep(1000);

                //Replace PhysicsUser line with SARC 2 name
                string[] fileText = File.ReadAllLines(ymlFile);
                for (int i = 0; i < fileText.Count(); i++)
                    if (fileText[i].Contains($"{oldLine}: "))
                        fileText[i] = $"{oldLine}: {newLine}".PadLeft(fileText[i].IndexOf(oldLine), ' ');

                //Overwrite YML with changes
                File.WriteAllLines(ymlFile, fileText);

                //Wait for YML file to be updated
                Thread.Sleep(1000);

                //Create new AAMP from YML, overwriting original
                Log($"Setting {oldLine} to {newLine} in {Path.GetFileName(originalDirectory)}...");
                RunCMD($"{pythonPath.Replace("python.exe", "Scripts\\yml_to_aamp.exe")} {ymlFile} {aampFile}");

                //Wait for AAMP file to be overwritten
                Thread.Sleep(500);

                //Move YML file to new directory for reference
                string newDir = Path.Combine(Path.GetDirectoryName(originalActorPath), $"{Path.GetFileNameWithoutExtension(originalActorPath)}_Edited_YML");
                string newFile = Path.Combine(newDir, Path.GetFileName(ymlFile));
                Directory.CreateDirectory(newDir);
                if (File.Exists(newFile))
                    File.Delete(newFile);
                File.Move(ymlFile, newFile);
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
    }
}
