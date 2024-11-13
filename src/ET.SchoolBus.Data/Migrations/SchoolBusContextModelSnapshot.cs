﻿// <auto-generated />
using System;
using ET.SchoolBus.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ET.SchoolBus.Data.Migrations
{
    [DbContext(typeof(SchoolBusContext))]
    partial class SchoolBusContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BrandId")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandId"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("BrandName")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedTime")
                        .HasColumnOrder(12);

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CreatedUser")
                        .HasColumnOrder(11);

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IsActive")
                        .HasColumnOrder(15)
                        .HasDefaultValueSql("1");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedTime")
                        .HasColumnOrder(14);

                    b.Property<string>("UpdatedUser")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UpdatedUser")
                        .HasColumnOrder(13);

                    b.HasKey("BrandId");

                    b.ToTable("Brands", (string)null);
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .HasColumnType("int")
                        .HasColumnName("DriverId")
                        .HasColumnOrder(1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Address")
                        .HasColumnOrder(6);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedTime")
                        .HasColumnOrder(12);

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CreatedUser")
                        .HasColumnOrder(11);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email")
                        .HasColumnOrder(7);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Name")
                        .HasColumnOrder(3);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)")
                        .HasColumnName("PhoneNumber")
                        .HasColumnOrder(5);

                    b.Property<int>("SchoolId")
                        .HasColumnType("int")
                        .HasColumnName("SchoolId")
                        .HasColumnOrder(2);

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IsActive")
                        .HasColumnOrder(15)
                        .HasDefaultValueSql("1");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Surname")
                        .HasColumnOrder(4);

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedTime")
                        .HasColumnOrder(14);

                    b.Property<string>("UpdatedUser")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UpdatedUser")
                        .HasColumnOrder(13);

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("DriverId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Drives", (string)null);
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.Hostes", b =>
                {
                    b.Property<int>("HostesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("HostesId")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HostesId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Address")
                        .HasColumnOrder(7);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedTime")
                        .HasColumnOrder(12);

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CreatedUser")
                        .HasColumnOrder(11);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email")
                        .HasColumnOrder(8);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Name")
                        .HasColumnOrder(4);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)")
                        .HasColumnName("PhoneNumber")
                        .HasColumnOrder(6);

                    b.Property<int>("SchoolId")
                        .HasColumnType("int")
                        .HasColumnName("SchoolId")
                        .HasColumnOrder(2);

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IsActive")
                        .HasColumnOrder(15)
                        .HasDefaultValueSql("1");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Surname")
                        .HasColumnOrder(5);

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedTime")
                        .HasColumnOrder(14);

                    b.Property<string>("UpdatedUser")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UpdatedUser")
                        .HasColumnOrder(13);

                    b.Property<int>("VehicleId")
                        .HasColumnType("int")
                        .HasColumnName("VehicleId")
                        .HasColumnOrder(3);

                    b.HasKey("HostesId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Hostesses", (string)null);
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.Model", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ModelId")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModelId"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int")
                        .HasColumnName("BrandId")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedTime")
                        .HasColumnOrder(12);

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CreatedUser")
                        .HasColumnOrder(11);

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("ModelName")
                        .HasColumnOrder(3);

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IsActive")
                        .HasColumnOrder(15)
                        .HasDefaultValueSql("1");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedTime")
                        .HasColumnOrder(14);

                    b.Property<string>("UpdatedUser")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UpdatedUser")
                        .HasColumnOrder(13);

                    b.HasKey("ModelId");

                    b.HasIndex("BrandId");

                    b.ToTable("Models", (string)null);
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.Parent", b =>
                {
                    b.Property<int>("ParentId")
                        .HasColumnType("int")
                        .HasColumnName("ParentId")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedTime")
                        .HasColumnOrder(12);

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CreatedUser")
                        .HasColumnOrder(11);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email")
                        .HasColumnOrder(7);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Name")
                        .HasColumnOrder(4);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)")
                        .HasColumnName("PhoneNumber")
                        .HasColumnOrder(6);

                    b.Property<int>("ProfessionId")
                        .HasColumnType("int")
                        .HasColumnName("ProfessionId")
                        .HasColumnOrder(2);

                    b.Property<int>("SchoolId")
                        .HasColumnType("int")
                        .HasColumnName("SchoolId")
                        .HasColumnOrder(3);

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IsActive")
                        .HasColumnOrder(15)
                        .HasDefaultValueSql("1");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Surname")
                        .HasColumnOrder(5);

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedTime")
                        .HasColumnOrder(14);

                    b.Property<string>("UpdatedUser")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UpdatedUser")
                        .HasColumnOrder(13);

                    b.HasKey("ParentId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Parents", (string)null);
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.Profession", b =>
                {
                    b.Property<int>("ProfessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProfessionId")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfessionId"));

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedTime")
                        .HasColumnOrder(12);

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CreatedUser")
                        .HasColumnOrder(11);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name")
                        .HasColumnOrder(2);

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IsActive")
                        .HasColumnOrder(15)
                        .HasDefaultValueSql("1");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedTime")
                        .HasColumnOrder(14);

                    b.Property<string>("UpdatedUser")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UpdatedUser")
                        .HasColumnOrder(13);

                    b.HasKey("ProfessionId");

                    b.ToTable("Professions", (string)null);
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.School", b =>
                {
                    b.Property<int>("SchoolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SchoolId")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SchoolId"));

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedTime")
                        .HasColumnOrder(12);

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CreatedUser")
                        .HasColumnOrder(11);

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("SchoolName")
                        .HasColumnOrder(2);

                    b.Property<int>("StartYear")
                        .HasColumnType("int")
                        .HasColumnName("StartYear")
                        .HasColumnOrder(4);

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IsActive")
                        .HasColumnOrder(15)
                        .HasDefaultValueSql("1");

                    b.Property<int>("StudentCount")
                        .HasColumnType("int")
                        .HasColumnName("StudentCount")
                        .HasColumnOrder(3);

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedTime")
                        .HasColumnOrder(14);

                    b.Property<string>("UpdatedUser")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UpdatedUser")
                        .HasColumnOrder(13);

                    b.HasKey("SchoolId");

                    b.ToTable("Schools", (string)null);
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("StudentId")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedTime")
                        .HasColumnOrder(12);

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CreatedUser")
                        .HasColumnOrder(11);

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnType("nchar(11)")
                        .HasColumnName("IdentityNumber")
                        .HasColumnOrder(4);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Name")
                        .HasColumnOrder(5);

                    b.Property<int>("SchoolId")
                        .HasColumnType("int")
                        .HasColumnName("SchoolId")
                        .HasColumnOrder(3);

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IsActive")
                        .HasColumnOrder(15)
                        .HasDefaultValueSql("1");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Surname")
                        .HasColumnOrder(6);

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float")
                        .HasColumnName("TotalPrice")
                        .HasColumnOrder(7);

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedTime")
                        .HasColumnOrder(14);

                    b.Property<string>("UpdatedUser")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UpdatedUser")
                        .HasColumnOrder(13);

                    b.Property<int>("VehicleId")
                        .HasColumnType("int")
                        .HasColumnName("VehicleId")
                        .HasColumnOrder(2);

                    b.HasKey("StudentId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.StudentParent", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("StudentId")
                        .HasColumnOrder(1);

                    b.Property<int>("ParentId")
                        .HasColumnType("int")
                        .HasColumnName("ParentId")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedTime")
                        .HasColumnOrder(12);

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CreatedUser")
                        .HasColumnOrder(11);

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IsActive")
                        .HasColumnOrder(15)
                        .HasDefaultValueSql("1");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedTime")
                        .HasColumnOrder(14);

                    b.Property<string>("UpdatedUser")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UpdatedUser")
                        .HasColumnOrder(13);

                    b.HasKey("StudentId", "ParentId");

                    b.HasIndex("ParentId");

                    b.ToTable("StudentParents", (string)null);
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .HasColumnType("int")
                        .HasColumnName("VehicleId")
                        .HasColumnOrder(1);

                    b.Property<int>("BrandId")
                        .HasColumnType("int")
                        .HasColumnName("BrandId")
                        .HasColumnOrder(3);

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("Capacity")
                        .HasColumnOrder(5);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedTime")
                        .HasColumnOrder(12);

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CreatedUser")
                        .HasColumnOrder(11);

                    b.Property<int>("ModelId")
                        .HasColumnType("int")
                        .HasColumnName("ModelId")
                        .HasColumnOrder(4);

                    b.Property<int>("ModelYear")
                        .HasColumnType("int")
                        .HasColumnName("ModelYear")
                        .HasColumnOrder(6);

                    b.Property<string>("Plaque")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int")
                        .HasColumnName("SchoolId")
                        .HasColumnOrder(2);

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IsActive")
                        .HasColumnOrder(15)
                        .HasDefaultValueSql("1");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedTime")
                        .HasColumnOrder(14);

                    b.Property<string>("UpdatedUser")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UpdatedUser")
                        .HasColumnOrder(13);

                    b.HasKey("VehicleId");

                    b.HasIndex("BrandId");

                    b.HasIndex("ModelId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Vehicles", (string)null);
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.Driver", b =>
                {
                    b.HasOne("ET.SchoolBus.Domain.Entities.Vehicle", "Vehicle")
                        .WithOne("Driver")
                        .HasForeignKey("ET.SchoolBus.Domain.Entities.Driver", "DriverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ET.SchoolBus.Domain.Entities.School", "School")
                        .WithMany("Drivers")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("School");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.Hostes", b =>
                {
                    b.HasOne("ET.SchoolBus.Domain.Entities.School", "School")
                        .WithMany("Hosteses")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.Model", b =>
                {
                    b.HasOne("ET.SchoolBus.Domain.Entities.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.Parent", b =>
                {
                    b.HasOne("ET.SchoolBus.Domain.Entities.Profession", "Profession")
                        .WithMany("Parents")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ET.SchoolBus.Domain.Entities.School", "School")
                        .WithMany("Parents")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Profession");

                    b.Navigation("School");
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.Student", b =>
                {
                    b.HasOne("ET.SchoolBus.Domain.Entities.School", "School")
                        .WithMany("Students")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ET.SchoolBus.Domain.Entities.Vehicle", "Vehicle")
                        .WithMany("Students")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("School");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.StudentParent", b =>
                {
                    b.HasOne("ET.SchoolBus.Domain.Entities.Parent", "Parent")
                        .WithMany("StudentParents")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ET.SchoolBus.Domain.Entities.Student", "Student")
                        .WithMany("StudentParents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.Vehicle", b =>
                {
                    b.HasOne("ET.SchoolBus.Domain.Entities.Brand", "Brand")
                        .WithMany("Vehicles")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ET.SchoolBus.Domain.Entities.Model", "Model")
                        .WithMany("Vehicles")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ET.SchoolBus.Domain.Entities.School", "School")
                        .WithMany("Vehicles")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ET.SchoolBus.Domain.Entities.Hostes", "Hostes")
                        .WithOne("Vehicle")
                        .HasForeignKey("ET.SchoolBus.Domain.Entities.Vehicle", "VehicleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Hostes");

                    b.Navigation("Model");

                    b.Navigation("School");
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.Brand", b =>
                {
                    b.Navigation("Models");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.Hostes", b =>
                {
                    b.Navigation("Vehicle")
                        .IsRequired();
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.Model", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.Parent", b =>
                {
                    b.Navigation("StudentParents");
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.Profession", b =>
                {
                    b.Navigation("Parents");
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.School", b =>
                {
                    b.Navigation("Drivers");

                    b.Navigation("Hosteses");

                    b.Navigation("Parents");

                    b.Navigation("Students");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.Student", b =>
                {
                    b.Navigation("StudentParents");
                });

            modelBuilder.Entity("ET.SchoolBus.Domain.Entities.Vehicle", b =>
                {
                    b.Navigation("Driver");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
