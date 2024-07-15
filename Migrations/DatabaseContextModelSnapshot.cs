﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RailwayScheduler.Database;

#nullable disable

namespace RailwayScheduler.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("RailwayScheduler.Models.Train", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TimeDestination")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TimeSource")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Trains");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Destination = "Station B",
                            Source = "Station A",
                            TimeDestination = 1000,
                            TimeSource = 800
                        },
                        new
                        {
                            Id = 2,
                            Destination = "Station D",
                            Source = "Station C",
                            TimeDestination = 1100,
                            TimeSource = 900
                        });
                });
#pragma warning restore 612, 618
        }
    }
}