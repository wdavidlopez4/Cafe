﻿// <auto-generated />
using Cafe.Configuration.Infrastructure.EFcore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cafe.Configuration.Infrastructure.Migrations
{
    [DbContext(typeof(CoffeeContext))]
    partial class CoffeeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cafe.Configuration.Domain.Entities.CoffeeGrower", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CoffeeGrowers");
                });

            modelBuilder.Entity("Cafe.Configuration.Domain.Entities.ConfigurationCrop", b =>
                {
                    b.Property<string>("CropId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CropId");

                    b.ToTable("ConfigurationCrop");
                });

            modelBuilder.Entity("Cafe.Configuration.Domain.Entities.Crop", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CoffeeGrowerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConfigurationCropId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DayFormation")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CoffeeGrowerId");

                    b.HasIndex("ConfigurationCropId")
                        .IsUnique()
                        .HasFilter("[ConfigurationCropId] IS NOT NULL");

                    b.ToTable("Crop");
                });

            modelBuilder.Entity("Cafe.Configuration.Domain.Entities.Crop", b =>
                {
                    b.HasOne("Cafe.Configuration.Domain.Entities.CoffeeGrower", "CoffeeGrower")
                        .WithMany("Crops")
                        .HasForeignKey("CoffeeGrowerId");

                    b.HasOne("Cafe.Configuration.Domain.Entities.ConfigurationCrop", "ConfigurationCrop")
                        .WithOne("Crop")
                        .HasForeignKey("Cafe.Configuration.Domain.Entities.Crop", "ConfigurationCropId");
                });
#pragma warning restore 612, 618
        }
    }
}
