using MedicalFacilityPortalDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace MedicalFacilityPortalDatabaseImplement
{
    public class MedicalFacilityPortalDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=PostgresqlDB;Username=postgres;Password=1234");
        }

        public virtual DbSet<Contract> Contracts { set; get; }
        public virtual DbSet<Doctor> Doctors { set; get; }
        public virtual DbSet<DoctorService> DoctorsServices { set; get; }
        public virtual DbSet<Job> Jobs { set; get; }
        public virtual DbSet<Patient> Patients { set; get; }
        public virtual DbSet<Service> Services { set; get; }
        public virtual DbSet<JobService> JobsServices { set; get; }

    }
}