using System.IO;
using System.Windows.Forms;

namespace LOLConfigChanger
{
    public class ConfigManager
    {
        
        public static string[] configFileNames = {"game.cfg", "PersistedSettings.json"};

        public static bool Backup()
        {
            string configFolder = Application.StartupPath + "\\config";
            if (!Directory.Exists(configFolder))
            {
                Directory.CreateDirectory(configFolder);
            }

            foreach (string configFileName in configFileNames)
            {
                string path = MainForm.Instance.txtClientPath.Text + "\\Config\\" + configFileName;
                if (!File.Exists(path)) return false;

                File.Copy(path, Application.StartupPath + "\\config\\" + configFileName, true);
            }

            return true;
        }

        public static bool Load()
        {
            foreach (string configFileName in configFileNames)
            {
                string path = Application.StartupPath + "\\config\\" + configFileName;
                if (!File.Exists(path)) return false;
                
                File.Copy(path, MainForm.Instance.txtClientPath.Text + "\\Config\\" + configFileName, true);
            }

            return true;
        }

    }
}