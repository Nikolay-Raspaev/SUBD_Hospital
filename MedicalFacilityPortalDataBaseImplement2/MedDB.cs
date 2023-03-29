using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MedicalFacilityPortalDataBaseImplement2;

public partial class MedDB : DbContext
{
    public MedDB()
    {
    }

    public MedDB(DbContextOptions<MedDB> options)
        : base(options)
    {
    }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<DoctorsServices> Doctorsservices { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Servicesjob> Servicesjobs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=testBDd;Username=postgres;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contracts_pkey");

            entity.ToTable("contracts");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DoctorsServicesId).HasColumnName("doctorsservicesid");
            entity.Property(e => e.ExecutionStatus)
                .HasMaxLength(50)
                .HasColumnName("executionstatus");
            entity.Property(e => e.ExerciseDate).HasColumnName("exercisedate");
            entity.Property(e => e.PatientId).HasColumnName("patientid");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");

            entity.HasOne(d => d.DoctorsServices).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.DoctorsServicesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkcontractdoctorsservices");

            entity.HasOne(d => d.Patient).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkcontractpatient");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doctors_pkey");

            entity.ToTable("doctors");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AcademicDegree)
                .HasMaxLength(50)
                .HasColumnName("academicdegree");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Education)
                .HasMaxLength(50)
                .HasColumnName("education");
            entity.Property(e => e.JobId).HasColumnName("jobid");
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .HasColumnName("name");
            entity.Property(e => e.PassportNumber).HasColumnName("passportnumber");
            entity.Property(e => e.PassportSeries).HasColumnName("passportseries");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(80)
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasMaxLength(80)
                .HasColumnName("surname");
            entity.Property(e => e.TelephoneNumber)
                .HasMaxLength(16)
                .HasColumnName("telephonenumber");

            entity.HasOne(d => d.Job).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkdoctorsjob");
        });

        modelBuilder.Entity<DoctorsServices>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doctorsservices_pkey");

            entity.ToTable("doctorsservices");

            entity.HasIndex(e => new { e.DoctorsId, e.ServicesId }, "doctorsservices_doctorsid_servicesid_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DoctorsId).HasColumnName("doctorsid");
            entity.Property(e => e.ServicesId).HasColumnName("servicesid");

            entity.HasOne(d => d.Doctors).WithMany(p => p.DoctorsServices)
                .HasForeignKey(d => d.DoctorsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkdoctorsservicesservices");

            entity.HasOne(d => d.Services).WithMany(p => p.DoctorsServices)
                .HasForeignKey(d => d.ServicesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkdoctorsservicesdoctors");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jobs_pkey");

            entity.ToTable("jobs");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .HasColumnName("jobtitle");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("patients_pkey");

            entity.ToTable("patients");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .HasColumnName("name");
            entity.Property(e => e.PassportNumber).HasColumnName("passportnumber");
            entity.Property(e => e.PassportSeries).HasColumnName("passportseries");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(80)
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasMaxLength(80)
                .HasColumnName("surname");
            entity.Property(e => e.TelephoneNumber)
                .HasMaxLength(16)
                .HasColumnName("telephonenumber");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("services_pkey");

            entity.ToTable("services");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
        });

        modelBuilder.Entity<Servicesjob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("servicesjobs_pkey");

            entity.ToTable("servicesjobs");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.JobId).HasColumnName("jobid");
            entity.Property(e => e.ServicesId).HasColumnName("servicesid");

            entity.HasOne(d => d.Job).WithMany(p => p.ServicesJobs)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkservicesjobjob");

            entity.HasOne(d => d.Services).WithMany(p => p.Servicesjobs)
                .HasForeignKey(d => d.ServicesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkservicesjobservices");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
