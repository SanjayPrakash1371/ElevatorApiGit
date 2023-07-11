﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sample.DbConnect;

#nullable disable

namespace Sample.Migrations
{
    [DbContext(typeof(AllDataAccess))]
    [Migration("20230711080031_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sample.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("empId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Sample.Models.P2P.PeerToPeer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Resultsid")
                        .HasColumnType("int");

                    b.Property<string>("awardCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("citation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("empId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("employeeId")
                        .HasColumnType("int");

                    b.Property<int?>("month")
                        .HasColumnType("int");

                    b.Property<string>("nominatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Resultsid");

                    b.HasIndex("employeeId");

                    b.ToTable("PeerToPeer");
                });

            modelBuilder.Entity("Sample.Models.P2P.PeerToPeerResults", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("citation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("employeeId")
                        .HasColumnType("int");

                    b.Property<string>("nomainatedEmpId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nomainaterId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("employeeId");

                    b.ToTable("PeerToPeerResults");
                });

            modelBuilder.Entity("Sample.Models.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("empId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("empId1")
                        .HasColumnType("int");

                    b.Property<string>("roles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("empId1");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Sample.Models.P2P.PeerToPeer", b =>
                {
                    b.HasOne("Sample.Models.P2P.PeerToPeerResults", "Results")
                        .WithMany()
                        .HasForeignKey("Resultsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sample.Models.Employee", "employee")
                        .WithMany()
                        .HasForeignKey("employeeId");

                    b.Navigation("Results");

                    b.Navigation("employee");
                });

            modelBuilder.Entity("Sample.Models.P2P.PeerToPeerResults", b =>
                {
                    b.HasOne("Sample.Models.Employee", "employee")
                        .WithMany()
                        .HasForeignKey("employeeId");

                    b.Navigation("employee");
                });

            modelBuilder.Entity("Sample.Models.Roles", b =>
                {
                    b.HasOne("Sample.Models.Employee", "emp")
                        .WithMany()
                        .HasForeignKey("empId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("emp");
                });
#pragma warning restore 612, 618
        }
    }
}
