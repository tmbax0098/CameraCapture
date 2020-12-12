using CameraCapture.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraCapture.Controllers
{
    class CaptureController
    {

        public CaptureSettingModel captureSettingModel { get; private set; }

        public static string CaptureSettingFile = "captureSetting";

        private string path = "";


        public CaptureController()
        {
            captureSettingModel = new CaptureSettingModel();
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + CaptureSettingFile;
            read();

        }

        private void read()
        {
            if (File.Exists(path))
            {
                string[] parts = File.ReadAllLines(path);

                if (parts.Length == 2)
                {
                    if (parts[0] == "0" || parts[0] == "1" || parts[0] == "2" || parts[0] == "3" || parts[0] == "4" || parts[0] == "5" || parts[0] == "6")
                    {
                        if (parts[1] == "0" || parts[1] == "1" || parts[1] == "2")
                        {
                            captureSettingModel.PictureSize = ushort.Parse(parts[0]);
                            captureSettingModel.PictureQuality = ushort.Parse(parts[1]);
                            return;
                        }
                    }
                }
            }

            captureSettingModel.PictureSize = 0;
            captureSettingModel.PictureQuality = 0;

            write();

        }

        public void write()
        {
            File.WriteAllLines(path, new string[] { captureSettingModel.PictureSize.ToString(), captureSettingModel.PictureQuality.ToString() });
        }


    }
}
