﻿// <auto-generated />
using DbAccess.AllDbAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbAccess.Migrations
{
    [DbContext(typeof(AllDbContext))]
    [Migration("20230709085931_OneToMany")]
    partial class OneToMany
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataModels.Models.Accounts", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<double>("balance")
                        .HasColumnType("float");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("usersid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("usersid");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DataModels.Models.Users", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataModels.Models.Accounts", b =>
                {
                    b.HasOne("DataModels.Models.Users", "users")
                        .WithMany("accounts")
                        .HasForeignKey("usersid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("users");
                });

            modelBuilder.Entity("DataModels.Models.Users", b =>
                {
                    b.Navigation("accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
