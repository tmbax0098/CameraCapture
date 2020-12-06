using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraCapture.Models
{
    class DvrObject
    {

        public DvrObject()
        {
            Address = "127.0.0.1";
            Port = "8000";
            Username = "admin";
            Password = "";
            Channel= "1";
        }

        public string Address { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Channel { get; set; }

    }
}
