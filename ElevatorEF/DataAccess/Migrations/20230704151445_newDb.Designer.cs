﻿// <auto-generated />
using System;
using DataAccess.DbAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(AllDbContext))]
    [Migration("20230704151445_newDb")]
    partial class newDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("logid")
                        .HasColumnType("int");

                    b.Property<int>("weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("logid");

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

            modelBuilder.Entity("Models.Models.ElevatorLogging", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("floorno")
                        .HasColumnType("int");

                    b.Property<int>("logid")
                        .HasColumnType("int");

                    b.Property<int>("weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("logid");

                    b.ToTable("elevatorLoggings");
                });

            modelBuilder.Entity("ElevatorEF.Models.ElevatorLogAccess", b =>
                {
                    b.HasOne("ElevatorEF.Models.LiftLog", "log")
                        .WithMany()
                        .HasForeignKey("logid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("log");
                });

            modelBuilder.Entity("ElevatorEF.Models.LiftLog", b =>
                {
                    b.HasOne("ElevatorEF.Models.Employee", "employee")
                        .WithMany()
                        .HasForeignKey("employeeId");

                    b.Navigation("employee");
                });

            modelBuilder.Entity("Models.Models.ElevatorLogging", b =>
                {
                    b.HasOne("ElevatorEF.Models.LiftLog", "log")
                        .WithMany()
                        .HasForeignKey("logid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("log");
                });
#pragma warning restore 612, 618
        }
    }
}
