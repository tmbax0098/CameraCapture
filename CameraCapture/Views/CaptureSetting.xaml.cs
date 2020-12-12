using CameraCapture.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CameraCapture.Views
{
    /// <summary>
    /// Interaction logic for CaptureSetting.xaml
    /// </summary>
    public partial class CaptureSetting : UserControl
    {

        CaptureController captureController = null;

        public CaptureSetting()
        {
            InitializeComponent();
            captureController = new CaptureController();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            captureController.captureSettingModel.PictureSize = (ushort)cbSize.SelectedIndex;
            captureController.captureSettingModel.PictureQuality = (ushort)cbQuality.SelectedIndex;

            captureController.write();
        }

        private void onLoad(object sender, RoutedEventArgs e)
        {
            cbQuality.SelectedIndex = captureController.captureSettingModel.PictureQuality;
            cbSize.SelectedIndex = captureController.captureSettingModel.PictureSize;
        }
    }
}
