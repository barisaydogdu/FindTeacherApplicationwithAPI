﻿// <auto-generated />
using System;
using FindTeacherAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FindTeacherAPI.Migrations
{
    [DbContext(typeof(FindTeacherAPIDbContext))]
    [Migration("20230627173300_newColumns")]
    partial class newColumns
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FindTeacherAPI.Models.Advert", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DesiredRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Subjects")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Advert");
                });

            modelBuilder.Entity("FindTeacherAPI.Models.Experience", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Institution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("FindTeacherAPI.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EducationLevel")
                        .HasColumnType("int");

                    b.Property<string>("SpecialRequests")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("FindTeacherAPI.Models.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("HourlyRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Specializations")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subjects")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("FindTeacherAPI.Models.Experience", b =>
                {
                    b.HasOne("FindTeacherAPI.Models.Teacher", null)
                        .WithMany("Experiences")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("FindTeacherAPI.Models.Teacher", b =>
                {
                    b.Navigation("Experiences");
                });
#pragma warning restore 612, 618
        }
    }
}
