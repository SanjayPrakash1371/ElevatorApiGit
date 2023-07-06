﻿// <auto-generated />
using System;
using DataAccess.DbAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(AllDbContext))]
    partial class AllDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ElevatorEF.Models.ElevatorLogAccess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("floorno")
                        .HasColumnType("int");

                    b.Property<int>("weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ElevatorLogs");
                });

            modelBuilder.Entity("ElevatorEF.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("height")
                        .HasColumnType("int");

                    b.Property<int?>("officefloor")
                        .HasColumnType("int");

                    b.Property<int?>("weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ElevatorEF.Models.LiftLog", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("empId")
                        .HasColumnType("int");

                    b.Property<int?>("employeeId")
                        .HasColumnType("int");

                    b.Property<int?>("end")
                        .HasColumnType("int");

                    b.Property<int?>("start")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("employeeId");

                    b.ToTable("LiftLogs");
                });

            modelBuilder.Entity("Models.Models.ElevatorLogDI", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ElevatorLogAccessId")
                        .HasColumnType("int");

                    b.Property<int?>("elogId")
                        .HasColumnType("int");

                    b.Property<int>("floorno")
                        .HasColumnType("int");

                    b.Property<int?>("liftlogid")
                        .HasColumnType("int");

                    b.Property<int?>("logLiftId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ElevatorLogAccessId");

                    b.HasIndex("liftlogid");

                    b.ToTable("elevatorLoggings");
                });

            modelBuilder.Entity("ElevatorEF.Models.LiftLog", b =>
                {
                    b.HasOne("ElevatorEF.Models.Employee", "employee")
                        .WithMany()
                        .HasForeignKey("employeeId");

                    b.Navigation("employee");
                });

            modelBuilder.Entity("Models.Models.ElevatorLogDI", b =>
                {
                    b.HasOne("ElevatorEF.Models.ElevatorLogAccess", "ElevatorLogAccess")
                        .WithMany()
                        .HasForeignKey("ElevatorLogAccessId");

                    b.HasOne("ElevatorEF.Models.LiftLog", "liftlog")
                        .WithMany()
                        .HasForeignKey("liftlogid");

                    b.Navigation("ElevatorLogAccess");

                    b.Navigation("liftlog");
                });
#pragma warning restore 612, 618
        }
    }
}
