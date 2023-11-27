﻿// <auto-generated />
using System;
using API_AppParkingSoft.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_AppParkingSoft.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20231127025123_testDB2")]
    partial class testDB2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API_AppParkingSoft.DAL.Entities.CategoryVehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CategoryVehicles");
                });

            modelBuilder.Entity("API_AppParkingSoft.DAL.Entities.Rate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryVehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("dailyRate")
                        .HasColumnType("float");

                    b.Property<double>("hourlyRate")
                        .HasColumnType("float");

                    b.Property<Guid>("idCategoryVehicle")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("monthlyRate")
                        .HasColumnType("float");

                    b.Property<double>("weeklyRate")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryVehicleId");

                    b.HasIndex("RateName")
                        .IsUnique();

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("API_AppParkingSoft.DAL.Entities.Reserve", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalCost")
                        .HasColumnType("float");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("activeVehicle")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Reserves");
                });

            modelBuilder.Entity("API_AppParkingSoft.DAL.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("idUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API_AppParkingSoft.DAL.Entities.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryVehicle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LicensePlate")
                        .IsUnique();

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("API_AppParkingSoft.DAL.Entities.Rate", b =>
                {
                    b.HasOne("API_AppParkingSoft.DAL.Entities.CategoryVehicle", "CategoryVehicle")
                        .WithMany("Rates")
                        .HasForeignKey("CategoryVehicleId");

                    b.Navigation("CategoryVehicle");
                });

            modelBuilder.Entity("API_AppParkingSoft.DAL.Entities.Reserve", b =>
                {
                    b.HasOne("API_AppParkingSoft.DAL.Entities.User", null)
                        .WithMany("Reserves")
                        .HasForeignKey("UserId");

                    b.HasOne("API_AppParkingSoft.DAL.Entities.Vehicle", null)
                        .WithMany("Reserves")
                        .HasForeignKey("VehicleId");
                });

            modelBuilder.Entity("API_AppParkingSoft.DAL.Entities.CategoryVehicle", b =>
                {
                    b.Navigation("Rates");
                });

            modelBuilder.Entity("API_AppParkingSoft.DAL.Entities.User", b =>
                {
                    b.Navigation("Reserves");
                });

            modelBuilder.Entity("API_AppParkingSoft.DAL.Entities.Vehicle", b =>
                {
                    b.Navigation("Reserves");
                });
#pragma warning restore 612, 618
        }
    }
}
