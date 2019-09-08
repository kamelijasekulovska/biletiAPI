﻿// <auto-generated />
using System;
using BiletiApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BiletiApp.API.Migrations
{
    [DbContext(typeof(BiletiDbContext))]
    [Migration("20190906205106_BiletiAPI.Models")]
    partial class BiletiAPIModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BiletiApp.API.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("Forname");

                    b.Property<string>("Surname");

                    b.Property<string>("Telephone");

                    b.Property<Guid?>("VenueId");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("BiletiApp.API.Models.Seat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Enabled");

                    b.Property<int>("Number");

                    b.Property<int>("Row");

                    b.Property<Guid?>("SectorId");

                    b.HasKey("Id");

                    b.HasIndex("SectorId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("BiletiApp.API.Models.Sector", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacity");

                    b.Property<string>("Label");

                    b.Property<string>("Name");

                    b.Property<int>("Rows");

                    b.Property<bool>("Seated");

                    b.Property<Guid?>("VenueId");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("BiletiApp.API.Models.Venue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacity");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("BiletiApp.API.Models.Contact", b =>
                {
                    b.HasOne("BiletiApp.API.Models.Venue")
                        .WithMany("Contacts")
                        .HasForeignKey("VenueId");
                });

            modelBuilder.Entity("BiletiApp.API.Models.Seat", b =>
                {
                    b.HasOne("BiletiApp.API.Models.Sector", "Sector")
                        .WithMany("Seats")
                        .HasForeignKey("SectorId");
                });

            modelBuilder.Entity("BiletiApp.API.Models.Sector", b =>
                {
                    b.HasOne("BiletiApp.API.Models.Venue")
                        .WithMany("Sectors")
                        .HasForeignKey("VenueId");
                });
#pragma warning restore 612, 618
        }
    }
}
