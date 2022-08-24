﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftActivities.Models;

#nullable disable

namespace SoftActivities.Migrations
{
    [DbContext(typeof(SoftActivitiesContext))]
    partial class SoftActivitiesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SoftActivities.Models.Date", b =>
                {
                    b.Property<int>("IdDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_DATE");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDate"), 1L, 1);

                    b.Property<DateTime>("DateS")
                        .HasColumnType("datetime")
                        .HasColumnName("DATE_S");

                    b.Property<int>("Hour")
                        .HasColumnType("int")
                        .HasColumnName("HOUR");

                    b.Property<int>("IdSchedule")
                        .HasColumnType("int")
                        .HasColumnName("ID_SCHEDULE");

                    b.HasKey("IdDate")
                        .HasName("PK__DATE__524C172F09899D28");

                    b.HasIndex("IdSchedule");

                    b.ToTable("DATE", (string)null);
                });

            modelBuilder.Entity("SoftActivities.Models.Schedule", b =>
                {
                    b.Property<int>("IdSchedule")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_SCHEDULE");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSchedule"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<int>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("ID_USER");

                    b.HasKey("IdSchedule")
                        .HasName("PK__SCHEDULE__AD4642E42D6CD594");

                    b.HasIndex("IdUser");

                    b.ToTable("SCHEDULE", (string)null);
                });

            modelBuilder.Entity("SoftActivities.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_USER");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("PASSWORD");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("USER_NAME");

                    b.HasKey("IdUser")
                        .HasName("PK__USERS__95F48440ECC75208");

                    b.ToTable("USERS", (string)null);

                    b.HasData(
                        new
                        {
                            IdUser = 1,
                            Password = "1234",
                            UserName = "Fraiden"
                        },
                        new
                        {
                            IdUser = 2,
                            Password = "1234",
                            UserName = "Chirs"
                        });
                });

            modelBuilder.Entity("SoftActivities.Models.Date", b =>
                {
                    b.HasOne("SoftActivities.Models.Schedule", "IdScheduleNavigation")
                        .WithMany("Dates")
                        .HasForeignKey("IdSchedule")
                        .IsRequired()
                        .HasConstraintName("FK__DATE__ID_SCHEDUL__3B75D760");

                    b.Navigation("IdScheduleNavigation");
                });

            modelBuilder.Entity("SoftActivities.Models.Schedule", b =>
                {
                    b.HasOne("SoftActivities.Models.User", "IdUserNavigation")
                        .WithMany("Schedules")
                        .HasForeignKey("IdUser")
                        .IsRequired()
                        .HasConstraintName("FK__SCHEDULE__ID_USE__38996AB5");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("SoftActivities.Models.Schedule", b =>
                {
                    b.Navigation("Dates");
                });

            modelBuilder.Entity("SoftActivities.Models.User", b =>
                {
                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}
