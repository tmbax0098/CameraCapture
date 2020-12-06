using CameraCapture.Models.Entites;
using CameraCapture.Models.Entites.Models;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CameraCapture.Entites
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext()
            : base(existingConnection: GetConnection(), contextOwnsConnection: false)
        {
            Database.CreateIfNotExists();
          //  Database.SetInitializer(new MigrateDatabaseToLatestVersion<PatientDbContext, CameraCapture.Migrations.Configuration>());
        }

        //public DbSet<Device> Devices { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static DbConnection GetConnection()
        {
            //project wpf hasta
            // string connectionString = System.Configuration.ConfigurationManager.AppSettings["PatientDbConnectionString"];//inja hast
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            //connectionString = connectionString.Replace("|DataDirectory|", Path.Combine(Application.StartupPath, "App_Data")).Replace("|Password|", "orf148600301");

            Debug.WriteLine("{0,-20}:{1}", "Connection String", connectionString);

            return new SqlCeConnection(connectionString);
        }
    }
}
