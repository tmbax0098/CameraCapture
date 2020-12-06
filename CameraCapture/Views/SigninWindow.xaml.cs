﻿using System;
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
    /// Interaction logic for SigninWindow.xaml
    /// </summary>
    public partial class SigninWindow : Window
    {
        public bool Loginstatus { get; private set; }
        public SigninWindow()
        {
            InitializeComponent();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Loginstatus = false;
            this.Close();
        }

        private void CheckLogin(object sender, RoutedEventArgs e)
        {
            lblResult.Content = "";
            if (txtUsername.Text == "admin")
            {
                string min = DateTime.Now.Minute.ToString();
                string hour = DateTime.Now.Hour.ToString();
                if (txtPassword.Password == "pass" + min + hour)
                {
                    Loginstatus = true;
                    this.Close();
                    return;
                }
            }
            lblResult.Content = "Fail login!";

        }
    }
}
