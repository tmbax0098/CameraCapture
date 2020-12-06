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
    /// Interaction logic for SerialPortControl.xaml
    /// </summary>
    public partial class SerialPortControl : UserControl
    {

        private SerialPortController serialPortController = null;


        public SerialPortControl()
        {
            InitializeComponent();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            serialPortController.Write(txtPortName.Text , txtBaudRate.Text);
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            serialPortController = new SerialPortController(false);
            txtPortName.Text = serialPortController.PortName;
            txtBaudRate.Text =  serialPortController.Baudrate.ToString();
        }
    }
}
