using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Updater
{

    internal struct VersionData
    {
        public string VersionNumber { get; set; }
        public string UpdateFileUrl { get; set; }

        public VersionData(string VersionNumber, string UpdateFileUrl)
        {
            this.VersionNumber = VersionNumber;
            this.UpdateFileUrl = UpdateFileUrl;
        }
    }

    public partial class Updater : Form
    {
        bool ProgramKilled = false;
        bool Updating = false;
        const string UPDATEURL = "https://github.com/Konstantinos-Papanagnou/Youtube-Downloader-And-Converter/raw/master/setup/Update/update.json";
        readonly int PID;
        readonly string LocalDownloadsPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "Pap Converter");
        readonly string VersionFolder; 
        readonly string VersionPath;
        const string setup = "https://github.com/Konstantinos-Papanagnou/Youtube-Downloader-And-Converter/raw/master/setup/Pap%20Converter%20Setup.exe";
        Thread UpdateThread;


        public Updater(int PID)
        {
            InitializeComponent();
            this.PID = PID;
            progressBar1.Visible = false;
            Progresslabel.Text = "Checking for Updates...";
            VersionFolder = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Pap Converter");
            VersionPath = System.IO.Path.Combine(VersionFolder, "version.txt");
            Directory.CreateDirectory(VersionFolder);
            UpdateThread = new Thread(new ThreadStart(BeginUpdate));
            UpdateThread.Start();
        }

        public void BeginUpdate()
        {
            try
            {
                if (CheckForUpdates(out VersionData ver_data))
                {
                    KillProgram();

                    DownloadAndInstall(ver_data);
                }
                else
                {
                    Invoke(new Action(() => Progresslabel.Text = "You are up to date!"));
                    Thread.Sleep(2000);
                    Application.Exit();
                }
            }
            catch (WebException)
            {
                Invoke(new Action(() => Progresslabel.Text = "Unable to establish connection to the internet. Check your network connection or try again later"));
            }
        }

        private void DownloadAndInstall(VersionData ver_data)
        {
            bool minor = CheckForMinor(ver_data.VersionNumber);

            string remoteUrl = minor ? ver_data.UpdateFileUrl : setup;
            Invoke(new Action(() => {
                Progresslabel.Text = "Downloading...";
                progressBar1.Visible = true;
            }));

            Directory.CreateDirectory(LocalDownloadsPath);
            if (File.Exists(Path.Combine(LocalDownloadsPath, "update.exe")))
                File.Delete(Path.Combine(LocalDownloadsPath, "update.exe"));
            using (WebClient client = new WebClient())
            {
                client.DownloadProgressChanged += (s, e) => { Invoke(new Action(() => { progressBar1.Value = e.ProgressPercentage; })); };
                client.DownloadFileCompleted += (s, e) => {
                    Invoke(new Action(() => {
                        progressBar1.Value = 100;
                        Progresslabel.Text = "Download Completed";
                    }));

                    if (Install())
                    {
                        Updating = false;
                        ConfigureUpdate(ver_data.VersionNumber);
                    }

                };
                client.DownloadFileAsync(new Uri(remoteUrl), Path.Combine(LocalDownloadsPath, "update.exe"));
            }
        }

        private bool CheckForMinor(string versionCode)
        {
            string localVer = GetCurrentVersion();
            return versionCode.Split('.')[1] == localVer.Split('.')[1] || int.Parse(versionCode.Split('.')[1]) - int.Parse(localVer.Split('.')[1]) == 1;
        }

        private bool Install()
        {
            Invoke(new Action(() =>
            {
                Progresslabel.Text = "Installing";
                progressBar1.Visible = false;
            }));

            const int ERR_CANCELED = 1224;
            System.Diagnostics.ProcessStartInfo update = new System.Diagnostics.ProcessStartInfo(Path.Combine(LocalDownloadsPath, "update.exe"))
            {
                UseShellExecute = true,
                Verb = "runas"
            };
            try
            {
                var installation = System.Diagnostics.Process.Start(update);
                Updating = true;
                installation.WaitForExit();
                Invoke(new Action(() =>
                {
                    Progresslabel.Text = "Installation Completed!";
                }));
                return true;
            }
            catch (Win32Exception ex)
            {
                if (ex.NativeErrorCode == ERR_CANCELED)
                    Invoke(new Action(() =>
                    {
                        Progresslabel.Text = "Installation Failed. Admin Priviledges Required!";
                    }));
                return false;
            }
        }

        private void ConfigureUpdate(string VersionData)
        {
            Invoke(new Action(() => {
                Progresslabel.Text = "Processing Triggers...";
            }));
            File.WriteAllText(VersionPath, VersionData);
            Invoke(new Action(() => {
                Progresslabel.Text = "Firing up Pap Converter!";
            }));

            StartProgram();
        }

        private void KillProgram()
        {
            if (ProgramKilled)
                return;
            if (PID == -1)
                return;
            System.Diagnostics.Process.GetProcessById(PID).Kill();
            ProgramKilled = true;
        }

        private void StartProgram()
        {
            if (ProgramKilled)
                System.Diagnostics.Process.Start("Pap Converter.exe");
        }

        private bool CheckForUpdates(out VersionData remoteUrl)
        {
            string currentVersion = GetCurrentVersion();
            VersionData data = GetCloudVersion();
            remoteUrl = data;
            return currentVersion != data.VersionNumber; // if current version is not equal to 
        }

        private string GetCurrentVersion()
        {
            Directory.CreateDirectory(VersionFolder);
            if (File.Exists(VersionPath))
            {
                string version = File.ReadAllText(VersionPath);
                return version;
            }
            else
            {
                return GetCloudVersion().VersionNumber;
            }
        }

        private VersionData GetCloudVersion()
        {
            VersionData data; 
            using (WebClient client = new WebClient())
                data = JsonConvert.DeserializeObject<VersionData>(client.DownloadString(UPDATEURL));
            return data;
        }

        private void Updater_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Updating)
            {
                StartProgram();
                UpdateThread.Abort();
                Application.Exit();
            }
            else MessageBox.Show("Pap Converter is Updating. Exiting the Updater during the update process is not recommended...", "Updater.exe");
        }
    }
}
