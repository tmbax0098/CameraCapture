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
using CameraCapture.Entites;
using CameraCapture.Models.Entites;
using CameraCapture.Models.Entites.Models;

namespace CameraCapture.Views
{
    /// <summary>
    /// Interaction logic for ArchiveControl.xaml
    /// </summary>
    public partial class ArchiveControl : UserControl
    {
        // private PatientDbContext patientDbContext = null;

        public ArchiveControl()
        {
            //PatientDbContext patientDbContext
            InitializeComponent();
            //  this.patientDbContext = patientDbContext;
        }

        private void AppendFilter(object sender, RoutedEventArgs e)
        {
            PatientDbContext patientDbContext = new PatientDbContext();
            string val = txtValue.Text;
            dataGrid.ItemsSource =
                patientDbContext
                .Patients
                .Where(i =>
                            i.FirstName.Contains(val) ||
                            i.LastName.Contains(val) ||
                            i.PatientId.Contains(val) ||
                            i.Title.Contains(val) && (
                            i.Created >= dtFromDate.DisplayDate &&
                            i.Created < dtFromDate.DisplayDate
                            )).ToList();

            patientDbContext.Dispose();


        }

        private void OpenDetailWindow(object sender, MouseButtonEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Patient patient = (Patient)(dataGrid.SelectedItem);
                ArchiveDetailWindow archiveDetailWindow = new ArchiveDetailWindow();
                archiveDetailWindow.SetPatientId(patient.Id);
                archiveDetailWindow.ShowDialog();

            }
        }

        private void ShowDetail(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Patient patient = (Patient)(dataGrid.SelectedItem);
                ArchiveDetailWindow archiveDetailWindow = new ArchiveDetailWindow();
                archiveDetailWindow.SetPatientId(patient.Id);
                archiveDetailWindow.ShowDialog();

            }
        }
    }
}
