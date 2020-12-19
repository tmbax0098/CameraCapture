using CameraCapture.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CameraCapture.Views
{
    /// <summary>
    /// Interaction logic for GalleryControl.xaml
    /// </summary>
    public partial class GalleryControl : UserControl
    {
        private int patientId = -1;

        public delegate void ChangeSelectedItem(BitmapImage bitmapImage);

        public event ChangeSelectedItem onChangeSelectedItem;

        private GalleryController galleryController = null;
        public GalleryControl()
        {
            InitializeComponent();
        }

        private void onLoad(object sender, RoutedEventArgs e)
        {
            galleryController = new GalleryController();
        }

        public void setGalleryId(int Id)
        {
            patientId = Id;
            if (galleryController == null)
            {
                galleryController = new GalleryController();
            }
            galleryController.CreateAndOpenGalley(Id);
            LoadGalleryImageList();
        }

        public void LoadGalleryImageList()
        {
            if (galleryController == null)
            {
                galleryController = new GalleryController();
                galleryController.CreateAndOpenGalley(patientId);
            }

            this.Dispatcher.Invoke(() =>
            {
                listBox.Items.Clear();

                galleryController.GetGalleryFilesList(patientId).ForEach((string path) =>
                {

                    byte[] array = File.ReadAllBytes(path);

                    Image image = new Image();
                    image.Source = galleryController.ConvertToImage(array);
                    ListBoxItem lbi = new ListBoxItem();
                    lbi.Width = 80;
                    lbi.Height = 80;
                    lbi.Content = image;
                    listBox.Items.Add(lbi);

                });

            });

        }

        private void DeleteItem(object sender, MouseButtonEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {

                galleryController.CreateAndOpenGalley(patientId);

                string path = galleryController.GetGalleryFilesList()[listBox.SelectedIndex];


                listBox.Items.Remove(listBox.SelectedItem);
                listBox.UpdateLayout();

                galleryController.DeleteImageFromGallery(path);

            }
        }

        private void LoadGallery(object sender, MouseButtonEventArgs e)
        {
            LoadGalleryImageList();
        }

        public void Clear()
        {
            listBox.Items.Clear();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedItem == null) return;


            ListBoxItem listBoxItem = (ListBoxItem)listBox.SelectedItem;
            Image image = (Image)listBoxItem.Content;


            var bitmapImage = (BitmapImage)image.Source;
            //string path = bitmapImage.UriSource.AbsolutePath;

            onChangeSelectedItem(bitmapImage);

        }
    }
}
