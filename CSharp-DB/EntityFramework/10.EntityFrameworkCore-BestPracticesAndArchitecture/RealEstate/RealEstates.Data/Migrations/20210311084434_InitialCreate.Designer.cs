﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstates.Data;

namespace RealEstates.Data.Migrations
{
    [DbContext(typeof(RealEstateDbContext))]
    [Migration("20210311084434_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RealEstates.Models.BuildingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BuildingTypes");
                });

            modelBuilder.Entity("RealEstates.Models.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("RealEstates.Models.PropertyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PropertyTypes");
                });

            modelBuilder.Entity("RealEstates.Models.RealEstateProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuildingTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("BuildingYear")
                        .HasColumnType("int");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<int?>("Floor")
                        .HasColumnType("int");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<int>("PropertyTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int?>("TotalNumberOfFloors")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuildingTypeId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("PropertyTypeId");

                    b.ToTable("RealEstateProperties");
                });

            modelBuilder.Entity("RealEstates.Models.RealEstatePropertyTag", b =>
                {
                    b.Property<int>("RealEstatePropertyId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("RealEstatePropertyId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("RealEstatePropertyTags");
                });

            modelBuilder.Entity("RealEstates.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("RealEstates.Models.RealEstateProperty", b =>
                {
                    b.HasOne("RealEstates.Models.BuildingType", "BuildingType")
                        .WithMany("RealEstateProperties")
                        .HasForeignKey("BuildingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstates.Models.District", "District")
                        .WithMany("RealEstateProperties")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RealEstates.Models.PropertyType", "PropertyType")
                        .WithMany("RealEstateProperties")
                        .HasForeignKey("PropertyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BuildingType");

                    b.Navigation("District");

                    b.Navigation("PropertyType");
                });

            modelBuilder.Entity("RealEstates.Models.RealEstatePropertyTag", b =>
                {
                    b.HasOne("RealEstates.Models.RealEstateProperty", "RealEstateProperty")
                        .WithMany("RealEstatePropertyTags")
                        .HasForeignKey("RealEstatePropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstates.Models.Tag", "Tag")
                        .WithMany("RealEstatePropertyTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RealEstateProperty");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("RealEstates.Models.BuildingType", b =>
                {
                    b.Navigation("RealEstateProperties");
                });

            modelBuilder.Entity("RealEstates.Models.District", b =>
                {
                    b.Navigation("RealEstateProperties");
                });

            modelBuilder.Entity("RealEstates.Models.PropertyType", b =>
                {
                    b.Navigation("RealEstateProperties");
                });

            modelBuilder.Entity("RealEstates.Models.RealEstateProperty", b =>
                {
                    b.Navigation("RealEstatePropertyTags");
                });

            modelBuilder.Entity("RealEstates.Models.Tag", b =>
                {
                    b.Navigation("RealEstatePropertyTags");
                });
#pragma warning restore 612, 618
        }
    }
}
