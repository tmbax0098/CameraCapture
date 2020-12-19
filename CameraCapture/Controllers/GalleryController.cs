using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ImageProcessor;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Interop;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;

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

        public void AppendImageToGallery(byte[] buffer, uint size)
        {

            string sJpegPicFileName = CurrentPatientGalleryPath;

            sJpegPicFileName += "\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpeg";


            FileStream fs = new FileStream(sJpegPicFileName, FileMode.Create);


            fs.Write(buffer, 0, (int)size);
            fs.Close();
            fs.Dispose();
        }

        //public Image ClipToCircle(System.Drawing.Image srcImage, PointF center, float radius, Color backGround)
        //{
        //    Image dstImage = new Bitmap(srcImage.Width, srcImage.Height, srcImage.PixelFormat);

        //    using (Graphics g = Graphics.FromImage(dstImage))
        //    {
        //        RectangleF r = new RectangleF(center.X - radius, center.Y - radius,
        //                                                 radius * 2, radius * 2);

        //        // enables smoothing of the edge of the circle (less pixelated)
        //        g.SmoothingMode = SmoothingMode.AntiAlias;

        //        // fills background color
        //        using (Brush br = new SolidBrush(backGround))
        //        {
        //            g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height);
        //        }

        //        // adds the new ellipse & draws the image again 
        //        GraphicsPath path = new GraphicsPath();
        //        path.AddEllipse(r);
        //        g.SetClip(path);
        //        g.DrawImage(srcImage, 0, 0);

        //        return dstImage;
        //    }
        //}

        //public byte[] ImageToByteArray(BitmapImage bitmapImage)
        //{
        //    byte[] data;
        //    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
        //    encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        encoder.Save(ms);
        //        data = ms.ToArray();
        //    }
        //    return data;
        //}

        //private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        //{

        //    using (MemoryStream outStream = new MemoryStream())
        //    {
        //        BitmapEncoder enc = new BmpBitmapEncoder();
        //        enc.Frames.Add(BitmapFrame.Create(bitmapImage));
        //        enc.Save(outStream);
        //        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

        //        return new Bitmap(bitmap);
        //    }
        //}

        //private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        //{
        //    // BitmapImage bitmapImage = new BitmapImage(new Uri("../Images/test.png", UriKind.Relative));

        //    using (MemoryStream outStream = new MemoryStream())
        //    {
        //        BitmapEncoder enc = new BmpBitmapEncoder();
        //        enc.Frames.Add(BitmapFrame.Create(bitmapImage));
        //        enc.Save(outStream);
        //        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

        //        return new Bitmap(bitmap);
        //    }
        //}


        //public Bitmap ResizeBitmap(Bitmap bm)
        //{


        //    int startX = (bm.Width - bm.Height) / 2;

        //    // Make rectangles representing the original and new dimensions.
        //    Rectangle src_rect = new Rectangle(0, 0, bm.Width, bm.Height);
        //    Rectangle dest_rect = new Rectangle(startX, 0, bm.Height + startX, bm.Height);

        //    // Make the new bitmap.
        //    Bitmap bm2 = new Bitmap(bm.Height, bm.Height);
        //    using (Graphics gr = Graphics.FromImage(bm2))
        //    {
        //        gr.InterpolationMode =
        //            InterpolationMode.HighQualityBicubic;
        //        gr.DrawImage(bm, dest_rect, src_rect,
        //            GraphicsUnit.Pixel);
        //    }

        //    return bm2;
        //}


        public Bitmap ResizeBitmap(Bitmap bmp)
        {
            int startX = (bmp.Width - bmp.Height) / 2;
            //Bitmap result = new Bitmap(bmp.Height, bmp.Height);
            Bitmap result = new Bitmap(bmp.Height, bmp.Height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, bmp.Height, bmp.Height);
            }

            return result;
        }


        public Bitmap ClipToCircle(Bitmap original, PointF center, float radius)
        {
            Bitmap copy = ResizeBitmap(new Bitmap(original));

            using (Graphics g = Graphics.FromImage(copy))
            {
                RectangleF r = new RectangleF(center.X - radius, center.Y - radius, radius * 2, radius * 2);
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(r);
                g.SetClip(path);
                g.DrawImage(original, 0, 0);
                return copy;
            };
        }

        //[System.Runtime.InteropServices.DllImport("gdi32.dll")]
        //public static extern bool DeleteObject(IntPtr hObject);

        //private BitmapImage Bitmap2BitmapImage(Bitmap bmp)
        //{


        //    var bitmapData = bmp.LockBits(
        //                 new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
        //                System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);

        //    var bitmapSource = BitmapSource.Create(
        //       bitmapData.Width, bitmapData.Height, 96, 96, PixelFormats.Bgr24, null,
        //       bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);

        //    bmp.UnlockBits(bitmapData);
        //    return BitmapImage;
        //}

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);

            return returnImage;
        }



        private Bitmap Array2Bitmap(byte[] byJpegPicBuffer)
        {

            using (var ms = new MemoryStream(byJpegPicBuffer))
            {
                Bitmap bitmap = new Bitmap(ms);

                return bitmap;
            };

        }

        public static byte[] ImageToByte(Bitmap img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }


        public BitmapImage ConvertToImage(byte[] byJpegPicBuffer)
        {

            if (byJpegPicBuffer == null || byJpegPicBuffer.Length == 0) return null;


            Bitmap bitmap = Array2Bitmap(byJpegPicBuffer);

            //double startX = (bitmap.Width - bitmap.Height) / 2;
            //double endX = bitmap.Width + startX;

            bitmap = ResizeBitmap(bitmap);


            var image = new BitmapImage();
            //using (var mem = new MemoryStream(ImageToByte(bitmap)))
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
