﻿// <auto-generated />
using System;
using BiletiApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BiletiApp.API.Migrations
{
    [DbContext(typeof(BiletiDbContext))]
    partial class BiletiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BiletiApp.API.Models.BiletiEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cover");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("Max_tickets_per_account");

                    b.Property<string>("Name");

                    b.Property<Guid?>("OrganizationId");

                    b.Property<Guid?>("VenueId");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("VenueId");

                    b.ToTable("BiletiEvents");
                });

            modelBuilder.Entity("BiletiApp.API.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("Forname");

                    b.Property<Guid?>("OrganizationId");

                    b.Property<string>("Surname");

                    b.Property<string>("Telephone");

                    b.Property<Guid?>("VenueId");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("VenueId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("BiletiApp.API.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BiletiEventId");

                    b.Property<Guid?>("OrganizationId");

                    b.Property<string>("Path");

                    b.HasKey("Id");

                    b.HasIndex("BiletiEventId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("BiletiApp.API.Models.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cover");

                    b.Property<string>("Description");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Logo");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
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

            modelBuilder.Entity("BiletiApp.API.Models.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BiletiEventId");

                    b.Property<string>("Label");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("BiletiEventId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("BiletiApp.API.Models.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Barcode");

                    b.Property<Guid?>("EventId");

                    b.Property<int>("Price");

                    b.Property<Guid?>("SeatId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("SeatId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("BiletiApp.API.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("TicketId");

                    b.Property<int>("TransactionStatus");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BiletiApp.API.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ContactId");

                    b.Property<Guid?>("OrganizationId");

                    b.Property<string>("Password");

                    b.Property<int>("UserRole");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Users");
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

            modelBuilder.Entity("BiletiApp.API.Models.BiletiEvent", b =>
                {
                    b.HasOne("BiletiApp.API.Models.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BiletiApp.API.Models.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("BiletiApp.API.Models.Contact", b =>
                {
                    b.HasOne("BiletiApp.API.Models.Organization")
                        .WithMany("Contacts")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("BiletiApp.API.Models.Venue")
                        .WithMany("Contacts")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("BiletiApp.API.Models.Image", b =>
                {
                    b.HasOne("BiletiApp.API.Models.BiletiEvent")
                        .WithMany("Images")
                        .HasForeignKey("BiletiEventId");

                    b.HasOne("BiletiApp.API.Models.Organization")
                        .WithMany("Gallery")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BiletiApp.API.Models.Seat", b =>
                {
                    b.HasOne("BiletiApp.API.Models.Sector")
                        .WithMany("Seats")
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BiletiApp.API.Models.Sector", b =>
                {
                    b.HasOne("BiletiApp.API.Models.Venue")
                        .WithMany("Sectors")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BiletiApp.API.Models.Tag", b =>
                {
                    b.HasOne("BiletiApp.API.Models.BiletiEvent")
                        .WithMany("Tags")
                        .HasForeignKey("BiletiEventId");
                });

            modelBuilder.Entity("BiletiApp.API.Models.Ticket", b =>
                {
                    b.HasOne("BiletiApp.API.Models.BiletiEvent", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BiletiApp.API.Models.Seat", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId");
                });

            modelBuilder.Entity("BiletiApp.API.Models.Transaction", b =>
                {
                    b.HasOne("BiletiApp.API.Models.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BiletiApp.API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BiletiApp.API.Models.User", b =>
                {
                    b.HasOne("BiletiApp.API.Models.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.HasOne("BiletiApp.API.Models.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
