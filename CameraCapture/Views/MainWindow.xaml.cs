using CameraCapture.Controllers;
using CameraCapture.Models;
using CameraCapture.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms.Integration;
using System.IO;
using System.Configuration;
using System.Data.SqlServerCe;
using CameraCapture.Entites;
using CameraCapture.Models.Entites.Models;
using System.Net.NetworkInformation;

namespace CameraCapture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PatientDbContext patientDbContext = null;
        SerialPortController serialPortController = null;
        DvrController dvrControl = null;
        CaptureController captureController = null;
        PedalController pedalController = null;
        private GalleryController galleryController = null;
        private int PatientId = -1;


        public delegate void ForTest();

        List<int> cameraList = null;
        private List<ChannelObject> ChannelModelList = null;
        private int selectedPatientId = -1;

        #region sdk

        private uint iLastErr = 0;
        private Int32 m_lUserID = -1;
        private bool m_bInitSDK = false;
        private bool m_bRecord = false;
        private bool m_bTalk = false;
        private Int32 m_lRealHandle = -1;
        private int lVoiceComHandle = -1;
        private string str;

        CHCNetSDK.REALDATACALLBACK RealData = null;
        public CHCNetSDK.NET_DVR_PTZPOS m_struPtzCfg;


        private bool _inLiveView = false;

        private uint dwAChanTotalNum = 0;
        private uint dwDChanTotalNum = 0;
        private Int32 i = 0;
        private int[] iChannelNum = new int[96];
        private int[] iIPDevID = new int[96];
        private long iSelIndex = 0;
        private PlayCtrl.DECCBFUN m_fDisplayFun = null;
        private Int32 m_lPort = -1;
        private Int32 m_lTree = 0;
        private IntPtr m_ptrRealHandle;
        private string str1;
        private string str2;
        public CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo;
        public CHCNetSDK.NET_DVR_IPCHANINFO m_struChanInfo;
        public CHCNetSDK.NET_DVR_IPCHANINFO_V40 m_struChanInfoV40;
        public CHCNetSDK.NET_DVR_IPPARACFG_V40 m_struIpParaCfgV40;
        public CHCNetSDK.NET_DVR_STREAM_MODE m_struStreamMode;
        public CHCNetSDK.NET_DVR_PU_STREAM_URL m_struStreamURL;

        public delegate void MyDebugInfo(string str);

        #endregion sdk



        public MainWindow()
        {
            InitializeComponent();
            InitialVariables();

            m_bInitSDK = CHCNetSDK.NET_DVR_Init();

            if (m_bInitSDK == false)
            {
                return;
            }
            else
            {
                for (int i = 0; i < 64; i++)
                {
                    iIPDevID[i] = -1;
                    iChannelNum[i] = -1;
                }
            }
        }

        public void InitialVariables()
        {

            serialPortController = new SerialPortController(true);
            serialPortController.PortOpen += () =>
            {
                // System.Windows.MessageBox.Show("port open");
                this.Dispatcher.Invoke(() =>
                {
                    imageSerialportStatus.Source = new BitmapImage(new Uri("/Resource/SerialPortSuccess.png", UriKind.Relative));
                });

            };
            serialPortController.PortClose += () =>
            {
                // System.Windows.MessageBox.Show("port closed");
                this.Dispatcher.Invoke(() =>
                {
                    imageSerialportStatus.Source = new BitmapImage(new Uri("/Resource/SerialPortFail.png", UriKind.Relative));
                });
            };
            serialPortController.NewDataReceived += (string data) =>
            {
                if (data.Substring(data.Length - 1, 1) == "\r")
                {
                    data = data.Substring(0, data.Length - 1);
                }
                //System.Windows.MessageBox.Show(data);
                switch (data)
                {
                    case "LIVE":
                        new Task(() => LivePreView()).Start();
                        break;
                    case "SAVE":
                        if (pedalController.SaveOnSave)
                        {
                            CaptureJpeg();
                        }
                        break;
                    case "FREEZE":

                        if (pedalController.SaveOnFreeze)
                        {
                            CaptureJpeg(false);
                        }

                        StopLivePreView();

                        break;

                }
            };

            dvrControl = new DvrController();
            galleryController = new GalleryController();
            pedalController = new PedalController();
            captureController = new CaptureController();

            ChannelModelList = new List<ChannelObject>();
            cameraList = new List<int>();

            patientDbContext = new PatientDbContext();

            dgTodayWorkBench.DataContext = patientDbContext.Patients.ToList();

            pateintTodayForm.nowRefresh += LoadTodayPatientTable;
            pateintTodayForm.onSelectPatient += (int Id, string fullName) =>
            {
                mainTabControl.SelectedIndex = 1;
                PatientId = Id;
                galleryController.CreateAndOpenGalley(Id);
                galleryControl.setGalleryId(Id);
                patientWorkBenchName.Text = fullName;
                picCapture.Source = null;


                partBottom.Visibility = Visibility.Collapsed;
            };


            galleryControl.onChangeSelectedItem += (BitmapImage bitmapImage) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    //BitmapImage btm = new BitmapImage(new Uri(path));
                    //ImageSource imageSource = new ImageSource()
                    picCapture.Source = bitmapImage;
                });
            };
        }


        private void startPingSamera()
        {
            while (true)
            {
                try
                {
                    Ping ping = new Ping();
                    PingReply pingresult = ping.Send(dvrControl.dvrObject.Address);
                    if (pingresult.Status == IPStatus.Success)
                    {
                        SuccessCamera();
                    }
                    else
                    {
                        FailCamera();
                    }
                    Thread.Sleep(2000);
                }
                catch
                {
                    FailCamera();
                    Thread.Sleep(2000);
                }
            }
        }

        #region camera functions -------------------------------

        private void LoginUser()
        {

            if (m_lUserID < 0)
            {
                string DVRIPAddress = dvrControl.dvrObject.Address; // Device IP
                Int16 DVRPortNumber = Int16.Parse(dvrControl.dvrObject.Port);// Device Port
                string DVRUserName = dvrControl.dvrObject.Username;// User name to login
                string DVRPassword = dvrControl.dvrObject.Password;// Password to login

                // Login the device
                m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
                if (m_lUserID < 0)
                {
                    //login fail 
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_Login_V30 failed, error code= " + iLastErr; //µÇÂ¼Ê§°Ü£¬Êä³ö´íÎóºÅ

                    return;
                }
                else
                {
                    //login success
                    //start live preview
                    // LivePreView();

                }

            }
        }

        private void LogoutUser()
        {
            if (m_lUserID >= 0)
            {
                //×¢ÏúµÇÂ¼ Logout the device
                if (m_lRealHandle >= 0)
                {
                    //MessageBox.Show("Please stop live view firstly");
                    return;
                }

                if (!CHCNetSDK.NET_DVR_Logout(m_lUserID))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_Logout failed, error code= " + iLastErr;
                    FailCamera();
                    return;
                }
                m_lUserID = -1;
            }
        }


        private void FailCamera()
        {
            this.Dispatcher.Invoke(() =>
            {
                imageCameraStatus.Source = new BitmapImage(new Uri("/Resource/CameraFail.png", UriKind.Relative));

            });
        }
        private void SuccessCamera()
        {
            this.Dispatcher.Invoke(() =>
            {
                imageCameraStatus.Source = new BitmapImage(new Uri("/Resource/CameraSuccess.png", UriKind.Relative));

            });
        }

        private void LivePreView()
        {
            // LoginUser();

            if (m_lUserID < 0)
            {
                LoginUser();
                return;
            }

            if (m_lRealHandle < 0)
            {
                CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                //lpPreviewInfo.byPreviewMode = CHCNetSDK.NET_DVR_PREVIEWINFO

                RealPlayWnd.Invoke(new ForTest(() =>
                {
                    lpPreviewInfo.hPlayWnd = RealPlayWnd.Handle;//Ô¤ÀÀ´°¿Ú
                }));

                lpPreviewInfo.lChannel = Int16.Parse(dvrControl.dvrObject.Channel);//channel value ===> [1,2,3,4,5,6]
                lpPreviewInfo.dwStreamType = 0;//ÂëÁ÷ÀàÐÍ£º0-Ö÷ÂëÁ÷£¬1-×ÓÂëÁ÷£¬2-ÂëÁ÷3£¬3-ÂëÁ÷4£¬ÒÔ´ËÀàÍÆ
                lpPreviewInfo.dwLinkMode = 0;//Á¬½Ó·½Ê½£º0- TCP·½Ê½£¬1- UDP·½Ê½£¬2- ¶à²¥·½Ê½£¬3- RTP·½Ê½£¬4-RTP/RTSP£¬5-RSTP/HTTP 
                lpPreviewInfo.bBlocked = true; //0- ·Ç×èÈûÈ¡Á÷£¬1- ×èÈûÈ¡Á÷
                lpPreviewInfo.dwDisplayBufNum = 1; //²¥·Å¿â²¥·Å»º³åÇø×î´ó»º³åÖ¡Êý
                lpPreviewInfo.byProtoType = 0;
                lpPreviewInfo.byPreviewMode = 0;


                if (RealData == null)
                {
                    RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//Ô¤ÀÀÊµÊ±Á÷»Øµ÷º¯Êý
                }

                IntPtr pUser = new IntPtr();//ÓÃ»§Êý¾Ý

                //´ò¿ªÔ¤ÀÀ Start live view 
                m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
                if (m_lRealHandle < 0)
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_RealPlay_V40 failed, error code= " + iLastErr; //Ô¤ÀÀÊ§°Ü£¬Êä³ö´íÎóºÅ
                                                                                  // FailCamera();

                    MessageControl messageControl = new MessageControl("Fail", str);
                    messageControl.ShowDialog();

                    return;
                }
                //SuccessCamera();
            }
            return;
        }


        private void StopLivePreView()
        {


            //Í£Ö¹Ô¤ÀÀ Stop live view 
            if (!CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_StopRealPlay failed, error code= " + iLastErr;
                //  MessageBox.Show(str);
                return;
            }
            m_lRealHandle = -1;
            //LogoutUser();
            //FailCamera();


        }

        public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
            if (dwBufSize > 0)
            {
                byte[] sData = new byte[dwBufSize];
                Marshal.Copy(pBuffer, sData, 0, (Int32)dwBufSize);

                string str = "ÊµÊ±Á÷Êý¾Ý.ps";
                FileStream fs = new FileStream(str, FileMode.Create);
                int iLen = (int)dwBufSize;
                fs.Write(sData, 0, iLen);
                fs.Close();
            }
        }



        private void CaptureJpeg(bool MoveImageToRight = true)
        {
            // int lChannel = iChannelNum[(int)iSelIndex]; //通道号 Channel number

            int lChannel = Int32.Parse(dvrControl.dvrObject.Channel);
            CHCNetSDK.NET_DVR_JPEGPARA lpJpegPara = new CHCNetSDK.NET_DVR_JPEGPARA();
            lpJpegPara.wPicQuality = captureController.captureSettingModel.PictureQuality; //图像质量 Image quality-----------------------------------------from 0 to 5 changed--------------------------------------
            lpJpegPara.wPicSize = captureController.captureSettingModel.PictureSize; //抓图分辨率 Picture size: 0xff-Auto(使用当前码流分辨率) 
            //抓图分辨率需要设备支持，更多取值请参考SDK文档

            //JPEG抓图保存成文件 Capture a JPEG picture
            string sJpegPicFileName;
            sJpegPicFileName = "reza.jpeg";//图片保存路径和文件名 the path and file name to save

            if (!CHCNetSDK.NET_DVR_CaptureJPEGPicture(m_lUserID, lChannel, ref lpJpegPara, sJpegPicFileName))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_CaptureJPEGPicture failed, error code= " + iLastErr;
                //DebugInfo(str);
                return;
            }
            else
            {
                str = "NET_DVR_CaptureJPEGPicture succ and the saved file is " + sJpegPicFileName;
                //DebugInfo(str);
            }

            //JEPG抓图，数据保存在缓冲区中 Capture a JPEG picture and save in the buffer
            uint iBuffSize = 400000; //缓冲区大小需要不小于一张图片数据的大小 The buffer size should not be less than the picture size
            byte[] byJpegPicBuffer = new byte[iBuffSize];
            uint dwSizeReturned = 0;

            if (!CHCNetSDK.NET_DVR_CaptureJPEGPicture_NEW(m_lUserID, lChannel, ref lpJpegPara, byJpegPicBuffer, iBuffSize, ref dwSizeReturned))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_CaptureJPEGPicture_NEW failed, error code= " + iLastErr;
                //DebugInfo(str);
                return;
            }
            else
            {

                if (MoveImageToRight)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        picCapture.Source = galleryController.ConvertToImage(byJpegPicBuffer);
                    });
                }
                galleryController.CreateAndOpenGalley(PatientId);
                galleryController.AppendImageToGallery(byJpegPicBuffer, dwSizeReturned);
                galleryControl.LoadGalleryImageList();


                str = "NET_DVR_CaptureJPEGPicture_NEW succ and save the data in buffer to 'buffertest.jpg'.";
                //DebugInfo(str);
            }

            return;
        }

        //private void CaptureJpeg()
        //{
        //    string sJpegPicFileName;
        //    //Í¼Æ¬±£´æÂ·¾¶ºÍÎÄ¼þÃû the path and file name to save
        //    sJpegPicFileName = "JPEG_test.jpg";

        //    int lChannel = Int16.Parse(dvrControl.dvrObject.Channel); //Í¨µÀºÅ Channel number

        //    CHCNetSDK.NET_DVR_JPEGPARA lpJpegPara = new CHCNetSDK.NET_DVR_JPEGPARA();
        //    lpJpegPara.wPicQuality = 0; //Í¼ÏñÖÊÁ¿ Image quality
        //    lpJpegPara.wPicSize = 0xff; //×¥Í¼·Ö±æÂÊ Picture size: 2- 4CIF£¬0xff- Auto(Ê¹ÓÃµ±Ç°ÂëÁ÷·Ö±æÂÊ)£¬×¥Í¼·Ö±æÂÊÐèÒªÉè±¸Ö§³Ö£¬¸ü¶àÈ¡ÖµÇë²Î¿¼SDKÎÄµµ

        //    //JPEG×¥Í¼ Capture a JPEG picture
        //    if (!CHCNetSDK.NET_DVR_CaptureJPEGPicture(m_lUserID, lChannel, ref lpJpegPara, sJpegPicFileName))
        //    {
        //        //fail capture
        //        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
        //        str = "NET_DVR_CaptureJPEGPicture failed, error code= " + iLastErr;
        //        //MessageBox.Show(str);
        //        return;
        //    }
        //    else
        //    {
        //        //success capture
        //        str = "Successful to capture the JPEG file and the saved file is " + sJpegPicFileName;
        //        //MessageBox.Show(str);
        //    }
        //    return;
        //}

        #endregion

        private void OpenSetting(object sender, MouseButtonEventArgs e)
        {
            SigninWindow signinWindow = new SigninWindow();
            signinWindow.ShowDialog();

            if (signinWindow.Loginstatus)
            {

                SettingWindow settingWindow = new SettingWindow();
                settingWindow.ShowDialog();
            }
        }

        private void OnLoadWindow(object sender, RoutedEventArgs e)
        {
            LoginUser();

            LoadTodayPatientTable();

            new Task(new Action(startPingSamera)).Start();

            //List<PatientViewModel> list = new List<PatientViewModel>();
            //list.Add(new PatientViewModel {
            //    Id = 0,
            //    Firstname = "asd",
            //    Lastname="3453fdsfada",
            //    PatientId="23446345",
            //    Title = "sdfgg"
            //});
            //list.Add(new PatientViewModel
            //{
            //    Id = 2,
            //    Firstname = "asd",
            //    Lastname = "3453fdsfada",
            //    PatientId = "23446345",
            //    Title = "sdfgg"
            //});

            //dgTodayWorkBench.ItemsSource = list;
        }

        private void CloseApplication(object sender, MouseButtonEventArgs e)
        {
            CloseWindow closeWindow = new CloseWindow();
            closeWindow.ShowDialog();
        }


        class PatientViewModel
        {

            public PatientViewModel() { }
            public int Id { get; set; }
            public string Title { get; set; }
            public string Name { get; set; }
            public string PatientId { get; set; }

        }



        #region today work

        private void LoadTodayPatientTable()
        {

            //patientDbContext = new PatientDbContext();

            dgTodayWorkBench.ItemsSource = patientDbContext.Patients.Select(i => new PatientViewModel
            {
                Id = i.Id,
                Title = i.Title,
                Name = i.FirstName + " " + i.LastName,
                PatientId = i.PatientId,
            }).ToList();
        }

        #endregion

        private void DgTodayWorkBench_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (PatientViewModel)((System.Windows.Controls.DataGrid)sender).SelectedItem;

            Patient pt = patientDbContext.Patients.FirstOrDefault(i => i.Id == item.Id);

            pateintTodayForm.setPatient(pt);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            galleryControl.Clear();
            galleryControl.setGalleryId(-1);
            PatientId = -1;
            galleryController.CreateAndOpenGalley(-1);
            patientWorkBenchName.Text = "No Patient";
            mainTabControl.SelectedIndex = 0;

            partBottom.Visibility = Visibility.Visible;

        }

        private void GoToArchiveTab(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = (System.Windows.Controls.Button)sender;

            if (mainTabControl.SelectedIndex == 0)
            {
                btn.Content = "Patient";
                mainTabControl.SelectedIndex = 2;
            }
            else
            {
                btn.Content = "Archive";
                mainTabControl.SelectedIndex = 0;
            }
        }

    }
}
