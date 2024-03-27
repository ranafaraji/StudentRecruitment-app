using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentRecuitmentProject.DBmodels;

public partial class StudentRecuitmentProjectDbContext : DbContext
{
    public StudentRecuitmentProjectDbContext()
    {
    }

    public StudentRecuitmentProjectDbContext(DbContextOptions<StudentRecuitmentProjectDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcademicHistory> AcademicHistories { get; set; }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=StudentRecruitment; Integrated Security=True; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcademicHistory>(entity =>
        {
            entity.HasKey(e => e.AcademicHistoryId).HasName("PK__Academic__6465946447EC07A4");

            entity.ToTable("AcademicHistory");

            entity.Property(e => e.AcademicHistoryId)
                .ValueGeneratedNever()
                .HasColumnName("AcademicHistoryID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Grade)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Course).WithMany(p => p.AcademicHistories)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__AcademicH__Cours__3C69FB99");

            entity.HasOne(d => d.Student).WithMany(p => p.AcademicHistories)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__AcademicH__Stude__3B75D760");
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("PK__Applicat__C93A4F79D8D338EB");

            entity.Property(e => e.ApplicationId)
                .ValueGeneratedNever()
                .HasColumnName("ApplicationID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Course).WithMany(p => p.Applications)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Applicati__Cours__403A8C7D");

            entity.HasOne(d => d.Student).WithMany(p => p.Applications)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Applicati__Stude__3F466844");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Courses__C92D7187BDED3377");

            entity.Property(e => e.CourseId)
                .ValueGeneratedNever()
                .HasColumnName("CourseID");
            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Department)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52A79A6453B27");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Program)
                .HasMaxLength(225)
                .IsUnicode(false);
            entity.Property(e => e.Region)
                .HasMaxLength(225)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
