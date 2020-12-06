using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CameraCapture.Controllers
{
    class GalleryController
    {

        public static string GallerySettingFile = "gallerySetting";

        private string path = "";

        public string GalleryPath { get; private set; }

        public string CurrentPatientGalleryPath { get; private set; }

        public GalleryController()
        {

            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + GallerySettingFile;
            read();
        }

        private void read()
        {
            if (File.Exists(path))
            {
                string[] parts = File.ReadAllLines(path);

                if (parts.Length == 1)
                {
                    GalleryPath = parts[0];
                    return;
                }
            }
            GalleryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\PatientGallery";

            write();

            if (!Directory.Exists(GalleryPath))
            {
                Directory.CreateDirectory(GalleryPath);
            }

        }

        public void write()
        {
            File.WriteAllLines(path, new string[] { GalleryPath });
        }

        public void write(string path)
        {
            GalleryPath = path;
            File.WriteAllLines(path, new string[] { GalleryPath });
        }

        public void CreateAndOpenGalley(int Id)
        {
            CurrentPatientGalleryPath = GalleryPath + "\\" + Id.ToString();
            if (!Directory.Exists(CurrentPatientGalleryPath))
            {
                Directory.CreateDirectory(CurrentPatientGalleryPath);
            }
        }

        public void AppendImageToGallery(byte[] byJpegPicBuffer, uint dwSizeReturned = 0)
        {

            string sJpegPicFileName = CurrentPatientGalleryPath;

            sJpegPicFileName += "\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpeg";//图片保存路径和文件名 the path and file name to save


            FileStream fs = new FileStream(sJpegPicFileName, FileMode.Create);
            int iLen = (int)dwSizeReturned;
            fs.Write(byJpegPicBuffer, 0, iLen);
            fs.Close();
            fs.Dispose();
        }

        public BitmapImage ConvertToImage(byte[] byJpegPicBuffer)
        {
            if (byJpegPicBuffer == null || byJpegPicBuffer.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(byJpegPicBuffer))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        public List<String> GetGalleryFilesList()
        {
            //CreateAndOpenGalley(pati)
            return Directory.GetFiles(CurrentPatientGalleryPath).ToList();
        }
        public List<String> GetGalleryFilesList(int patientId)
        {
            CreateAndOpenGalley(patientId);
            return Directory.GetFiles(CurrentPatientGalleryPath).ToList();
        }

        public void DeleteImageFromGallery(string path)
        {

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
