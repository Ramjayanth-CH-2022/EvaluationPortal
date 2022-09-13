using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EvaluationPortal.Models
{
    public partial class evaluation_portalContext : DbContext
    {
        public evaluation_portalContext()
        {
        }

        public evaluation_portalContext(DbContextOptions<evaluation_portalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<QuestionBank> QuestionBanks { get; set; } = null!;
        public virtual DbSet<QuestionPattern> QuestionPatterns { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<TestAttendeeHistory> TestAttendeeHistories { get; set; } = null!;
        public virtual DbSet<TestHistory> TestHistories { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=evaluation_portal;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionBank>(entity =>
            {
                entity.HasKey(e => e.QuestionId)
                    .HasName("PK__Question__0DC06FAC83C182B8");

                entity.ToTable("QuestionBank");

                entity.Property(e => e.Answer).HasMaxLength(100);

                entity.Property(e => e.Option1).HasMaxLength(100);

                entity.Property(e => e.Option2).HasMaxLength(100);

                entity.Property(e => e.Option3).HasMaxLength(100);

                entity.Property(e => e.Option4).HasMaxLength(100);

                entity.Property(e => e.Question).HasMaxLength(1000);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.QuestionBanks)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__QuestionB__Subje__3A81B327");
            });

            modelBuilder.Entity<QuestionPattern>(entity =>
            {
                entity.ToTable("QuestionPattern");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestAttendeeHistory>(entity =>
            {
                entity.HasKey(e => e.QuestionPaperCode)
                    .HasName("PK__TestAtte__F3E9C6A049DFBBC4");

                entity.ToTable("TestAttendeeHistory");

                entity.Property(e => e.DateOfExam).HasMaxLength(10);

                entity.Property(e => e.ExamEndTime).HasColumnType("datetime");

                entity.Property(e => e.ExamStartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.TestAttendeeHistories)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__TestAtten__Subje__3D5E1FD2");
            });

            modelBuilder.Entity<TestHistory>(entity =>
            {
                entity.HasKey(e => e.SerialNumber)
                    .HasName("PK__TestHist__048A000977F1EC08");

                entity.ToTable("TestHistory");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.TestHistories)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__TestHisto__Quest__4222D4EF");

                entity.HasOne(d => d.QuestionPaperCodeNavigation)
                    .WithMany(p => p.TestHistories)
                    .HasForeignKey(d => d.QuestionPaperCode)
                    .HasConstraintName("FK__TestHisto__Quest__412EB0B6");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TestHistories)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__TestHisto__UserI__403A8C7D");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Password).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
