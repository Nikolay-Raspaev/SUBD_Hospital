using System;
using System.Collections.Generic;
using HospitalDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalDatabaseImplement;

public partial class HospitalBdContext : DbContext
{
    public HospitalBdContext()
    {
    }

    public HospitalBdContext(DbContextOptions<HospitalBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Academicrank> Academicranks { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Doctorsservice> Doctorsservices { get; set; }

    public virtual DbSet<Executionstatus> Executionstatuses { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Servicesjob> Servicesjobs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=HospitalBD;Username=postgres;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Academicrank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("academicranks_pkey");

            entity.ToTable("academicranks");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Academicrankname)
                .HasMaxLength(50)
                .HasColumnName("academicrankname");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contracts_pkey");

            entity.ToTable("contracts");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Contractdoctorsid).HasColumnName("contractdoctorsid");
            entity.Property(e => e.Contractservicesid).HasColumnName("contractservicesid");
            entity.Property(e => e.Executionstatusid).HasColumnName("executionstatusid");
            entity.Property(e => e.Exercisedate).HasColumnName("exercisedate");
            entity.Property(e => e.Patientid).HasColumnName("patientid");

            entity.HasOne(d => d.Executionstatus).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.Executionstatusid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_contract_execution_status");

            entity.HasOne(d => d.Patient).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.Patientid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_contract_patient");

            entity.HasOne(d => d.ContractNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => new { d.Contractdoctorsid, d.Contractservicesid })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_contract_doctors_services");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doctors_pkey");

            entity.ToTable("doctors");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Academicrankid).HasColumnName("academicrankid");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Education)
                .HasMaxLength(50)
                .HasColumnName("education");
            entity.Property(e => e.Jobid).HasColumnName("jobid");
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .HasColumnName("name");
            entity.Property(e => e.Passport)
                .HasMaxLength(10)
                .HasColumnName("passport");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(80)
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasMaxLength(80)
                .HasColumnName("surname");
            entity.Property(e => e.Telephonenumber)
                .HasMaxLength(16)
                .HasColumnName("telephonenumber");

            entity.HasOne(d => d.Academicrank).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.Academicrankid)
                .HasConstraintName("fk_doctors_academic_rank");

            entity.HasOne(d => d.Job).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.Jobid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_doctors_job");
        });

        modelBuilder.Entity<Doctorsservice>(entity =>
        {
            entity.HasKey(e => new { e.Doctorsid, e.Servicesid }).HasName("doctorsservices_pkey");

            entity.ToTable("doctorsservices");

            entity.Property(e => e.Doctorsid).HasColumnName("doctorsid");
            entity.Property(e => e.Servicesid).HasColumnName("servicesid");

            entity.HasOne(d => d.Doctors).WithMany(p => p.Doctorsservices)
                .HasForeignKey(d => d.Doctorsid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_doctors_services_services");

            entity.HasOne(d => d.Services).WithMany(p => p.Doctorsservices)
                .HasForeignKey(d => d.Servicesid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_doctors_services_doctors");
        });

        modelBuilder.Entity<Executionstatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("executionstatus_pkey");

            entity.ToTable("executionstatus");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Executionstatus1)
                .HasMaxLength(80)
                .HasColumnName("executionstatus");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jobs_pkey");

            entity.ToTable("jobs");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Jobtitle)
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
            entity.Property(e => e.Passport)
                .HasMaxLength(10)
                .HasColumnName("passport");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(80)
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasMaxLength(80)
                .HasColumnName("surname");
            entity.Property(e => e.TelephoneNumber)
                .HasMaxLength(16)
                .HasColumnName("telephone_number");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("services_pkey");

            entity.ToTable("services");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Servicesname)
                .HasMaxLength(30)
                .HasColumnName("servicesname");
            entity.Property(e => e.Servicesprice)
                .HasPrecision(10, 2)
                .HasColumnName("servicesprice");
        });

        modelBuilder.Entity<Servicesjob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("servicesjobs_pkey");

            entity.ToTable("servicesjobs");

            entity.HasIndex(e => new { e.Servicesid, e.Jobid }, "servicesjobs_servicesid_jobid_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Jobid).HasColumnName("jobid");
            entity.Property(e => e.Servicesid).HasColumnName("servicesid");

            entity.HasOne(d => d.Job).WithMany(p => p.Servicesjobs)
                .HasForeignKey(d => d.Jobid)
                .HasConstraintName("fkservicesjobjob");

            entity.HasOne(d => d.Services).WithMany(p => p.Servicesjobs)
                .HasForeignKey(d => d.Servicesid)
                .HasConstraintName("fkservicesjobservices");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
