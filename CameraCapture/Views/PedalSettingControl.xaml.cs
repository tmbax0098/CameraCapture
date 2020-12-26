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
    /// Interaction logic for PedalSettingControl.xaml
    /// </summary>
    public partial class PedalSettingControl : UserControl
    {

        PedalController pedalController = null;

        public PedalSettingControl()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            pedalController.SaveOnFreeze = cbSaveOnFreeze.IsChecked == true ? true : false;
            pedalController.SaveOnSave = cbSaveOnSave.IsChecked == true ? true : false;
            pedalController.SetImageRightOnSave = cbSetRightOnSave.IsChecked == true ? true : false;

            pedalController.Write();
        }

        private void onLoad(object sender, RoutedEventArgs e)
        {
            pedalController = new PedalController();
            cbSaveOnFreeze.IsChecked = pedalController.SaveOnFreeze;
            cbSaveOnSave.IsChecked = pedalController.SaveOnSave;
            cbSetRightOnSave.IsChecked = pedalController.SetImageRightOnSave;
        }
    }
}
