using CameraCapture.Controllers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CameraCapture.Views
{
    /// <summary>
    /// Interaction logic for GallerySettingControl.xaml
    /// </summary>
    public partial class GallerySettingControl : System.Windows.Controls.UserControl
    {
        private GalleryController galleryController = null;

        FolderBrowserDialog folderBrowserDialog;
        public GallerySettingControl()
        {
            InitializeComponent();
        }


        private void Save(object sender, RoutedEventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {

                galleryController.write(folderBrowserDialog.SelectedPath);
                txtAddress.Text = galleryController.GalleryPath;
            }
        }

        private void onLoad(object sender, RoutedEventArgs e)
        {
            folderBrowserDialog = new FolderBrowserDialog();
            galleryController = new GalleryController();
            txtAddress.Text = galleryController.GalleryPath;
        }
    }
}
