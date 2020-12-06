using CameraCapture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace CameraCapture.Controllers
{
    class DvrController
    {


        public DvrObject dvrObject { get; private set; }

        public static string DvrSettingFile = "dvrSetting";

        private string path = "";

        public DvrController()
        {

            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + DvrSettingFile;

            dvrObject = new DvrObject();

            read();
        }

        private void read()
        {
            if (File.Exists(path))
            {
                string[] parts = File.ReadAllLines(path);

                if (parts.Length == 5)
                {
                    dvrObject.Address = parts[0];
                    dvrObject.Port = parts[1];
                    dvrObject.Username = parts[2];
                    dvrObject.Password = parts[3];
                    dvrObject.Channel = parts[4];
                }
            }

        }

        public void write()
        {
            File.WriteAllLines(path, new string[] { dvrObject.Address, dvrObject.Port, dvrObject.Username, dvrObject.Password });
        }



    }
}
