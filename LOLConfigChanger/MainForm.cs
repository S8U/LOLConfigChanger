using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace LOLConfigChanger
{
    public partial class MainForm : Form
    {

        public static MainForm Instance;

        private string regProgramName = "LOLConfigChanger";
        private string regStartUpPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        public MainForm()
        {
            Instance = this;
            
            InitializeComponent();

            /* Find League of Lengends folder */
            foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
            {
                string path = driveInfo.Name + "Riot Games\\League of Legends";
                if (File.Exists(path + "\\LeagueClient.exe"))
                {
                    txtClientPath.Text = path;
                    break;
                }
            }

            if (txtClientPath.Text.Length < 1)
            {
                MessageBox.Show("롤 경로를 찾을 수 없습니다.");
            }

            /* Check startup registry */
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(regStartUpPath);
            chkStart.Checked = registryKey.GetValue(regProgramName) != null;

            /* Tray */
            if (Environment.GetCommandLineArgs().Contains("/background"))
            {
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
            }
            
            /* Start auto load task */
            chkAutoLoad.Checked = Properties.Settings.Default.autoLoad;
        }
        
        private void MainForm_Shown(object sender, EventArgs e)
        {
            /* Tray */
            if (Environment.GetCommandLineArgs().Contains("/background"))
            {
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
                txtClientPath.Text = dialog.FileName;
            }
        }

        /* Save and load League of Legends config */
        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (ConfigManager.Backup())
            {
                MessageBox.Show("현재 설정을 백업했습니다.");
            }
            else
            {
                MessageBox.Show("설정 파일을 찾을 수 없습니다.");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (ConfigManager.Load())
            {
                MessageBox.Show("설정을 불러왔습니다.");
            }
            else
            {
                MessageBox.Show("설정 파일을 찾을 수 없습니다.");
            }
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

        /* Auto load config */
        private void chkAutoLoad_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoLoad = chkAutoLoad.Checked;
            Properties.Settings.Default.Save();
            
            if (chkAutoLoad.Checked)
            {
                ClientDetector.Start();
            }
        }

    }
}