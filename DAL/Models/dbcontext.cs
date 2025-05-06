using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class dbcontext : DbContext
{
    public dbcontext()
    {
    }

    public dbcontext(DbContextOptions<dbcontext> options)
        : base(options)
    {
    }

    public virtual DbSet<Archive> Archives { get; set; }

    public virtual DbSet<AvailableQueue> AvailableQueues { get; set; }

    public virtual DbSet<Clinic> Clinics { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Queue> Queues { get; set; }

    public virtual DbSet<Speciality> Specialities { get; set; }

    public virtual DbSet<WorkingTime> WorkingTimes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=Y:\\תיקייה כללית חדש\\שנה ב תשפה\\קבוצה ב\\תלמידות\\תלמידות\\ברין רחלי\\db.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Archive>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC0718BA5E97");

            entity.ToTable("Archive");

            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Hour).HasColumnName("hour");
            entity.Property(e => e.IdClinic).HasColumnName("idClinic");
            entity.Property(e => e.IdDoctor)
                .HasMaxLength(9)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("idDoctor");
            entity.Property(e => e.IdPatient)
                .HasMaxLength(9)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("idPatient");
            entity.Property(e => e.IsPayed)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("isPayed");
            entity.Property(e => e.Minute).HasColumnName("minute");

            entity.HasOne(d => d.IdClinicNavigation).WithMany(p => p.Archives)
                .HasForeignKey(d => d.IdClinic)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Archive_ToClinic");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.Archives)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Archive_ToDoctor");

            entity.HasOne(d => d.IdPatientNavigation).WithMany(p => p.Archives)
                .HasForeignKey(d => d.IdPatient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Archive_ToPatient");
        });

        modelBuilder.Entity<AvailableQueue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07501D5291");

            entity.ToTable("AvailableQueue");

            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Hour).HasColumnName("hour");
            entity.Property(e => e.IdClinic).HasColumnName("idClinic");
            entity.Property(e => e.IdDoctor)
                .HasMaxLength(9)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("idDoctor");
            entity.Property(e => e.Minute).HasColumnName("minute");

            entity.HasOne(d => d.IdClinicNavigation).WithMany(p => p.AvailableQueues)
                .HasForeignKey(d => d.IdClinic)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AvailableQueue_ToClinic");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.AvailableQueues)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AvailableQueue_ToDoctor");
        });

        modelBuilder.Entity<Clinic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clinic__3214EC07C1FB503A");

            entity.ToTable("Clinic");

            entity.Property(e => e.City)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("city");
            entity.Property(e => e.Street)
                .HasMaxLength(25)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("street");
            entity.Property(e => e.StreetNumber).HasColumnName("streetNumber");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Doctor__3214EC07B998D9B5");

            entity.ToTable("Doctor");

            entity.Property(e => e.Id)
                .HasMaxLength(9)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("lastName");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("phone");
            entity.Property(e => e.Speciality).HasColumnName("speciality");

            entity.HasOne(d => d.SpecialityNavigation).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.Speciality)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doctor_ToSpeciality");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient__3214EC073DACB029");

            entity.ToTable("Patient");

            entity.Property(e => e.Id)
                .HasMaxLength(9)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("birthDate");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasDefaultValueSql("('Jerusalem')")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("city");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("firstName");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("lastName");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("phone");
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("street");
            entity.Property(e => e.StreetNumber).HasColumnName("streetNumber");
        });

        modelBuilder.Entity<Queue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Queue__3214EC07BC39374D");

            entity.ToTable("Queue");

            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("description");
            entity.Property(e => e.EndHour).HasColumnName("endHour");
            entity.Property(e => e.EndMinute).HasColumnName("endMinute");
            entity.Property(e => e.IdClinic).HasColumnName("idClinic");
            entity.Property(e => e.IdDoctor)
                .HasMaxLength(9)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("idDoctor");
            entity.Property(e => e.IdPatient)
                .HasMaxLength(9)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("idPatient");
            entity.Property(e => e.IsReminded).HasColumnName("isReminded");
            entity.Property(e => e.StartHour).HasColumnName("startHour");
            entity.Property(e => e.StartMinute).HasColumnName("startMinute");

            entity.HasOne(d => d.IdClinicNavigation).WithMany(p => p.Queues)
                .HasForeignKey(d => d.IdClinic)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Queue_ToClinic");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.Queues)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Queue_ToDoctor");

            entity.HasOne(d => d.IdPatientNavigation).WithMany(p => p.Queues)
                .HasForeignKey(d => d.IdPatient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Queue_ToPatient");
        });

        modelBuilder.Entity<Speciality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Speciali__3214EC07E73EB805");

            entity.ToTable("Speciality");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("description");
        });

        modelBuilder.Entity<WorkingTime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC074C5E05DA");

            entity.ToTable("Working time");

            entity.Property(e => e.DayWeek)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("dayWeek");
            entity.Property(e => e.EndHour).HasColumnName("endHour");
            entity.Property(e => e.EndMinute).HasColumnName("endMinute");
            entity.Property(e => e.IdClinic).HasColumnName("idClinic");
            entity.Property(e => e.IdDoctor)
                .HasMaxLength(9)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("idDoctor");
            entity.Property(e => e.StartHour).HasColumnName("startHour");
            entity.Property(e => e.StartMinute).HasColumnName("startMinute");

            entity.HasOne(d => d.IdClinicNavigation).WithMany(p => p.WorkingTimes)
                .HasForeignKey(d => d.IdClinic)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Working time_ToClinic");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.WorkingTimes)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Working time_ToDoctor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
