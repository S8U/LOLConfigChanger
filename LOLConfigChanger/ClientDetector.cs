using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOLConfigChanger
{
    public class ClientDetector
    {

        public static bool running;

        public static FileSystemWatcher watcher;
        
        public static void Start()
        {
            Task.Run(Detect);
        }

        public static async void Detect()
        {
            while (MainForm.Instance.chkAutoLoad.Checked)
            {
                if (Process.GetProcessesByName("LeagueClientUx").Length == 0)
                {
                    running = false;
                } else if (!running)
                {
                    running = true;
                    OnDetect();
                }
                
                await Task.Delay(1000);
            }
        }

        public static void OnDetect()
        {
            if (watcher == null)
            {
                watcher = new FileSystemWatcher();
                watcher.Changed += async (sender, args) =>
                {
                    watcher.EnableRaisingEvents = false;

                    await Task.Delay(5000);

                    if (ConfigManager.Load())
                    {
                        MainForm.Instance.icnTray.ShowBalloonTip(1000, "", "설정을 불러왔습니다.", ToolTipIcon.Info);
                    }
                };
            }
            watcher.Path = MainForm.Instance.txtClientPath.Text + "\\Config\\";
            watcher.Filter = ConfigManager.configFileNames[1];
            watcher.EnableRaisingEvents = true;
        }
        
    }
}