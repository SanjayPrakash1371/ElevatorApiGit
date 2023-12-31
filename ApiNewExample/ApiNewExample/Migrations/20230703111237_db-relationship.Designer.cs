﻿// <auto-generated />
using System;
using ApiNewExample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiNewExample.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20230703111237_db-relationship")]
    partial class dbrelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiNewExample.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("LiftLoggerid")
                        .HasColumnType("int");

                    b.Property<int>("height")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("officeFloor")
                        .HasColumnType("int");

                    b.Property<int>("weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("LiftLoggerid");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ApiNewExample.Models.LiftLogger", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("floorno")
                        .HasColumnType("int");

                    b.Property<int>("weights")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("liftLoggers");
                });

            modelBuilder.Entity("ApiNewExample.Models.Employee", b =>
                {
                    b.HasOne("ApiNewExample.Models.Employee", null)
                        .WithMany("employees")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("ApiNewExample.Models.LiftLogger", null)
                        .WithMany("employees")
                        .HasForeignKey("LiftLoggerid");
                });

            modelBuilder.Entity("ApiNewExample.Models.Employee", b =>
                {
                    b.Navigation("employees");
                });

            modelBuilder.Entity("ApiNewExample.Models.LiftLogger", b =>
                {
                    b.Navigation("employees");
                });
#pragma warning restore 612, 618
        }
    }
}
