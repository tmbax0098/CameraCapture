using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraCapture.Controllers
{
    class OtherController
    {

        public double Ratio { get; private set; }

        public static string RatioSettingFile = "ratioSetting";

        private string path = "";


        public OtherController()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + RatioSettingFile;
            read();

        }

        private void read()
        {
            if (File.Exists(path))
            {
                string[] parts = File.ReadAllLines(path);

                if (parts.Length > 0)
                {
                    double number = 0;

                   // Console.WriteLine("length is ==============> " + parts[0].Length.ToString());

                    if (double.TryParse(parts[0], out number))
                    {
                        Ratio = number;
                        return;
                    }
                }
            }

            Ratio = 1;

            write();

        }

        public void write()
        {
            File.WriteAllLines(path, new string[] { Ratio.ToString() });
        }


    }
}
