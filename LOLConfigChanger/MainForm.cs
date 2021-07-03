using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace LOLConfigChanger
{
    public partial class frmMain : Form
    {
        private string clientPath;

        private string[] configFileNames = {"game.cfg", "PersistedSettings.json"};

        private string regProgramName = "LOLConfigChanger";
        private string regStartUpPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        public frmMain()
        {
            InitializeComponent();

            /* Find League of Lengends folder */
            foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
            {
                string path = driveInfo.Name + "Riot Games\\League of Legends";
                if (File.Exists(path + "\\LeagueClient.exe"))
                {
                    clientPath = path;
                    break;
                }
            }

            if (clientPath == null)
            {
                MessageBox.Show("롤 경로를 찾을 수 없습니다.");
            }
            else
            {
                txtClientPath.Text = clientPath;
            }

            /* Check startup registry */
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(regStartUpPath);
            chkStart.Checked = registryKey.GetValue(regProgramName) != null;

            /* Tray */
            if (Environment.GetCommandLineArgs().Contains("/background"))
            {
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
                Visible = false;
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Visible = false;
            }
        }
        
        /* Select League of Legends folder */
        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                clientPath = dialog.FileName;
                txtClientPath.Text = clientPath;
            }
        }

        /* Save and load League of Legends config */
        private void btnSave_Click(object sender, EventArgs e)
        {
            string configFolder = Application.StartupPath + "\\config";
            if (!Directory.Exists(configFolder))
            {
                Directory.CreateDirectory(configFolder);
            }

            foreach (string configFileName in configFileNames)
            {
                string path = clientPath + "\\Config\\" + configFileName;
                if (File.Exists(path))
                {
                    File.Copy(path, Application.StartupPath + "\\config\\" + configFileName, true);
                }
                else
                {
                    MessageBox.Show("설정 파일을 찾을 수 없습니다.");
                    return;
                }
            }

            MessageBox.Show("현재 설정을 저장했습니다.");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            foreach (string configFileName in configFileNames)
            {
                string path = Application.StartupPath + "\\config\\" + configFileName;
                if (File.Exists(path))
                {
                    File.Copy(path, clientPath + "\\Config\\" + configFileName, true);
                }
                else
                {
                    MessageBox.Show("설정 파일을 찾을 수 없습니다.");
                    return;
                }
            }

            MessageBox.Show("설정을 불러왔습니다.");
        }

        /* Startup config */
        private void chkStart_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(regStartUpPath, true);

            if (chkStart.Checked)
            {
                registryKey.SetValue(regProgramName, "\"" + Application.ExecutablePath + "\" /background");
            }
            else
            {
                registryKey.DeleteValue(regProgramName);
            }

            registryKey.Close();
        }

        /* Tray */
        private void icnTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tsmiOpen_Click(null, null);
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}