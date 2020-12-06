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
    /// Interaction logic for MessageControl.xaml
    /// </summary>
    public partial class MessageControl : Window
    {
        public MessageControl(string title , string message)
        {
            InitializeComponent();

            lblTitle.Content = title;
            lblMessage.Text = message;
        }

        private void CloseMessage(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
