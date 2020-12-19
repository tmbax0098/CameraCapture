using CameraCapture.Entites;
using CameraCapture.Models;
using CameraCapture.Models.Entites.Models;
using CameraCapture.Models.Types;
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
    /// Interaction logic for PatientControl.xaml
    /// </summary>
    public partial class PatientControl : UserControl
    {

        PatientDbContext patientDbContext = null;
        public PatientControl()
        {
            InitializeComponent();
            patientDbContext = new PatientDbContext();
            patient = new Patient();
            patient.Id = -1;
        }

        public delegate void Refresh();
        public delegate void Select(int Id, string fullname);

        public event Refresh nowRefresh;
        public event Select onSelectPatient;



        public Patient patient { get; private set; }


        public void setPatient(Patient patient)
        {
            if (patient == null) return;
            this.patient = patient;

            this.txtNote.Text = patient.Note;
            this.txtFirstName.Text = patient.FirstName;
            this.txtLastName.Text = patient.LastName;
            this.txtPatientId.Text = patient.PatientId;
            this.dtBirthday.DisplayDate = patient.Birthday.Value;
            //this.txtTitle.Text = patient.T;
            this.txtAge.Text = patient.Age.ToString();

            this.cbAgeType.SelectedIndex = (int)patient.AgeType;

            this.rdMale.IsChecked = patient.Gender == Models.Types.GenderType.Male;
            this.rdFemale.IsChecked = patient.Gender == Models.Types.GenderType.Female;

            //this.cbPregnant.IsChecked = patient.Pregnant;
            this.cbNa.IsChecked = patient.NA ? true : false;

            this.txtStudyDescription.Text = patient.StudyDescription;
            this.dtStudyDate.DisplayDate = patient.StudyDate.Value;
            this.txtAccessionNumber.Text = patient.AccessionNumber;
            this.txtRequestingPhysician.Text = patient.RequestingPhysician;

        }

        private void Save(object sender, RoutedEventArgs e)
        {


            patient.Title = txtTitle.Text;
            patient.FirstName = txtFirstName.Text;
            patient.LastName = txtLastName.Text;
            patient.PatientId = txtPatientId.Text;

            patient.Birthday = dtBirthday.DisplayDate;

            patient.Age = Int32.Parse(txtAge.Text != "" ? txtAge.Text : "0");
            patient.AgeType = cbAgeType.SelectedIndex == 0 ? AgeType.Year : AgeType.Month;

            patient.StudyDate = dtStudyDate.DisplayDate;
            patient.StudyDescription = txtStudyDescription.Text;
            patient.RequestingPhysician = txtRequestingPhysician.Text;
            patient.AccessionNumber = txtAccessionNumber.Text;
            patient.Note = txtNote.Text;

            //patient.Pregnant = cbPregnant.IsChecked == true ? true : false;
            patient.NA = cbNa.IsChecked == true ? true : false;

            patient.Gender = rdMale.IsChecked == true ? GenderType.Male : rdFemale.IsChecked == true ? GenderType.Female : GenderType.None;


            if (patient.FirstName.Trim() == "")
            {
                MessageControl messageControl = new MessageControl("Warning", "Please enter firstname!");
                messageControl.ShowDialog();
            }
            else if (patient.LastName.Trim() == "")
            {
                MessageControl messageControl = new MessageControl("Warning", "Please enter lastname!");
                messageControl.ShowDialog();
            }
            else if (patient.PatientId.Trim() == "")
            {
                MessageControl messageControl = new MessageControl("Warning", "Please enter patient ID!");
                messageControl.ShowDialog();
            }
            else
            {
                var item = patientDbContext.Patients.FirstOrDefault(i => i.Id == patient.Id);
                if (item == null || item.Id == -1)
                {
                    patient.Created = DateTime.Now;
                    patientDbContext.Patients.Add(patient);
                }
                else
                {
                    item = patient;
                }
                int value = patientDbContext.SaveChanges();

                if (value > -1)
                {
                    // MessageBox.Show("salam pesar!");
                    nowRefresh();
                }
            }

        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            this.txtTitle.Text = "";
            this.txtNote.Text = "";
            this.txtFirstName.Text = "";
            this.txtLastName.Text = "";
            this.txtPatientId.Text = "";
            this.dtBirthday.DisplayDate = DateTime.Now;
            //this.txtTitle.Text = patient.T;
            this.txtAge.Text = "";

            this.cbAgeType.SelectedIndex = 0;

            this.rdMale.IsChecked = false;
            this.rdFemale.IsChecked = false;

            //this.cbPregnant.IsChecked = false;
            this.cbNa.IsChecked = false;

            this.txtStudyDescription.Text = "";
            this.dtStudyDate.DisplayDate = DateTime.Now;
            this.txtAccessionNumber.Text = "";
            this.txtRequestingPhysician.Text = "";

            patient = new Patient();
            patient.Id = -1;
        }

        private void MoveToWorkbench(object sender, RoutedEventArgs e)
        {
            if (patient.Id != -1 )
            {
                onSelectPatient(patient.Id, patient.FirstName + " " + patient.LastName);
            }
            else
            {
                MessageControl messageControl = new MessageControl("Warning", "Please choose a patient!");
                messageControl.ShowDialog();
                //MessageBox.Show("Please choose a patient!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
