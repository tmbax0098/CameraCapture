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
    /// Interaction logic for DvrSettingControl.xaml
    /// </summary>
    public partial class DvrSettingControl : UserControl
    {

        Controllers.DvrController dvrController = null;

        public DvrSettingControl()
        {
            InitializeComponent();
        }

        private void Save(object sender, RoutedEventArgs e)
        {


            dvrController.dvrObject.Address = txtDvrAddress.Text;
            dvrController.dvrObject.Port = txtDvrPort.Text;
            dvrController.dvrObject.Username = txtDvrUsername.Text;
            dvrController.dvrObject.Password = txtDvrPassword.Text;
            dvrController.dvrObject.Channel = txtDvrChannel.Text;

            dvrController.write();

        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            dvrController = new Controllers.DvrController();

            txtDvrAddress.Text = dvrController.dvrObject.Address;
            txtDvrPort.Text = dvrController.dvrObject.Port;
            txtDvrUsername.Text = dvrController.dvrObject.Username;
            txtDvrPassword.Text = dvrController.dvrObject.Password;
            txtDvrChannel.Text = dvrController.dvrObject.Channel;

        }
    }
}
