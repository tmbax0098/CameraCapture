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
using System.Windows.Shapes;

namespace CameraCapture.Views
{
    /// <summary>
    /// Interaction logic for ArchiveDetailWindow.xaml
    /// </summary>
    public partial class ArchiveDetailWindow : Window
    {
        public BitmapImage SelectedImage { get; private set; }
        public int SelectedPatientId { get; private set; }
        public ArchiveDetailWindow()
        {
            InitializeComponent();
            SelectedPatientId = -1;

            gallery.onChangeSelectedItem += (BitmapImage bitmapImage) =>
            {
                SelectedImage = bitmapImage;
            };
        }

        public void SetPatientId(int Id)
        {

            SelectedPatientId = Id;
            gallery.setGalleryId(Id);
            gallery.LoadGalleryImageList();
        }

        private void SetImageToLeft(object sender, RoutedEventArgs e)
        {
            if (SelectedImage != null)
            {
                imageLeft.Source = SelectedImage;
                SelectedImage = null;
            }
        }

        private void SetImageToRight(object sender, RoutedEventArgs e)
        {
            if (SelectedImage != null)
            {
                imageRight.Source = SelectedImage;
                SelectedImage = null;
            }
        }

        private void CloseThisWindow(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
