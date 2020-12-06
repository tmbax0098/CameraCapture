using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;
using System.Threading;

namespace CameraCapture.Controllers
{
    class SerialPortController
    {
        public static string SerialportSettingFile = "serialportSetting";

        private string path = "";


        private SerialPort serialPort;

        public delegate void Data(string data);
        public delegate void Status();

        public event Data NewDataReceived;
        public event Status PortOpen;
        public event Status PortClose;

        public string PortName { get; private set; }
        public int Baudrate { get; private set; }

        public SerialPortController()
        {
            init();
           // new Task(() => ChangePortStatus()).Start();
        }

        private void init()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + SerialportSettingFile;

            LoadSetting();

            serialPort = new SerialPort(PortName, Baudrate);

            serialPort.ErrorReceived += (object sender, SerialErrorReceivedEventArgs e) =>
            {
                if (!serialPort.IsOpen)
                {
                    PortClose();
                    OpenPort();
                }
            };

            serialPort.Disposed += (object sender, EventArgs e) =>
            {
                PortClose();
            };


            serialPort.DataReceived += (object sender, SerialDataReceivedEventArgs e) =>
            {
                NewDataReceived(((SerialPort)sender).ReadLine());
            };

            new Task(() => OpenPort()).Start();

        }

        public SerialPortController(bool autoStart = true)
        {
            if (autoStart)
            {
                init();
            }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + SerialportSettingFile;

                LoadSetting();
            }
        }

        private void OpenPort()
        {
            while (true)
            {
                Thread.Sleep(1000);
                try
                {
                    if (serialPort == null || !serialPort.IsOpen)
                    {
                        PortClose();
                        Thread.Sleep(1000);
                        serialPort.Open();

                        if (serialPort.IsOpen)
                        {
                            PortOpen();
                        }
                    }
                }
                catch
                {
                }
            }
        }

        public void LoadSetting()
        {

            if (File.Exists(path))
            {
                string[] parts = File.ReadAllLines(path);

                if (parts.Length == 2)
                {
                    PortName = parts[0];
                    Baudrate = Int32.Parse(parts[1]);
                    return;
                }
            }

            PortName = "COM8";
            Baudrate = 9600;

            Write();

        }

        public void Write()
        {
            File.WriteAllLines(path, new string[] { PortName, Baudrate.ToString() });
        }

        public void Write(string PortName, string Baudrate)
        {
            File.WriteAllLines(path, new string[] { PortName, Baudrate });
        }


        //private void ChangePortStatus()
        //{
            
        //    if (serialPort == null || !serialPort.IsOpen)
        //    {
        //        PortClose();
        //        Thread.Sleep(1000);
        //        OpenPort();
        //    }
        //    Thread.Sleep(1000);
        //    ChangePortStatus();
        //}

    }
}
