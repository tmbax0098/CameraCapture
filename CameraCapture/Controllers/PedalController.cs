using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraCapture.Controllers
{
    class PedalController
    {

        public static string PedalSettingFile = "pedalSetting";

        private string path = "";

        public bool SaveOnFreeze { get; set; }
        public bool SaveOnSave { get; set; }



        public PedalController()
        {
            
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + PedalSettingFile;

            read();
        }

        private void read()
        {
            if (File.Exists(path))
            {
                string[] parts = File.ReadAllLines(path);

                if (parts.Length == 2)
                {
                    SaveOnFreeze = parts[0] == "1";
                    SaveOnSave = parts[1] == "1";
                    return;
                }
            }

            SaveOnFreeze = false;
            SaveOnSave = true;

            Write();
        }

        public void Write()
        {
            File.WriteAllLines(path, new string[] { SaveOnFreeze ? "1" : "0", SaveOnSave ? "1" : "0" });
        }




    }
}
