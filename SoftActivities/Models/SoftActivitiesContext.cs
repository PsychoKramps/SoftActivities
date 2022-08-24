using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SoftActivities.Models
{
    public partial class SoftActivitiesContext : DbContext
    {
        public SoftActivitiesContext()
        {
        }

        public SoftActivitiesContext(DbContextOptions<SoftActivitiesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Date> Dates { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PSYCHOKRAMPS\\SQLEXPRESS;Database=SoftActivities;Integrated Security = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Date>(entity =>
            {
                entity.HasKey(e => e.IdDate)
                    .HasName("PK__DATE__524C172F09899D28");

                entity.ToTable("DATE");

                entity.Property(e => e.IdDate).HasColumnName("ID_DATE");

                entity.Property(e => e.DateS)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_S");

                entity.Property(e => e.Hour).HasColumnName("HOUR");

                entity.Property(e => e.IdSchedule).HasColumnName("ID_SCHEDULE");

                entity.HasOne(d => d.IdScheduleNavigation)
                    .WithMany(p => p.Dates)
                    .HasForeignKey(d => d.IdSchedule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DATE__ID_SCHEDUL__3B75D760");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.IdSchedule)
                    .HasName("PK__SCHEDULE__AD4642E42D6CD594");

                entity.ToTable("SCHEDULE");

                entity.Property(e => e.IdSchedule).HasColumnName("ID_SCHEDULE");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SCHEDULE__ID_USE__38996AB5");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__USERS__95F48440ECC75208");

                entity.ToTable("USERS");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");
            });

            OnModelCreatingPartial(modelBuilder);

        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
