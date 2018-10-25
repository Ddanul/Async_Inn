﻿// <auto-generated />
using System;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsyncInn.Migrations
{
    [DbContext(typeof(AsyncInnDBContext))]
    [Migration("20181025184953_AddedModels")]
    partial class AddedModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsyncInn.Models.Amenities", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("RoomAmenitiesAmenitiesID");

                    b.Property<int?>("RoomAmenitiesRoomID");

                    b.HasKey("ID");

                    b.HasIndex("RoomAmenitiesAmenitiesID", "RoomAmenitiesRoomID");

                    b.ToTable("Amenities");
                });

            modelBuilder.Entity("AsyncInn.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int?>("HotelRoomHotelID");

                    b.Property<int?>("HotelRoomRoomNumber");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.HasKey("ID");

                    b.HasIndex("HotelRoomHotelID", "HotelRoomRoomNumber");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelID");

                    b.Property<int>("RoomNumber");

                    b.Property<bool>("PetFriendly");

                    b.Property<decimal>("Rate");

                    b.Property<decimal>("RoomID");

                    b.HasKey("HotelID", "RoomNumber");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("AsyncInn.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HotelRoomHotelID");

                    b.Property<int?>("HotelRoomRoomNumber");

                    b.Property<int>("Layout");

                    b.Property<string>("Name");

                    b.Property<int?>("RoomAmenitiesAmenitiesID");

                    b.Property<int?>("RoomAmenitiesRoomID");

                    b.HasKey("ID");

                    b.HasIndex("HotelRoomHotelID", "HotelRoomRoomNumber");

                    b.HasIndex("RoomAmenitiesAmenitiesID", "RoomAmenitiesRoomID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.Property<int>("AmenitiesID");

                    b.Property<int>("RoomID");

                    b.HasKey("AmenitiesID", "RoomID");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("AsyncInn.Models.Amenities", b =>
                {
                    b.HasOne("AsyncInn.Models.RoomAmenities")
                        .WithMany("Amenities")
                        .HasForeignKey("RoomAmenitiesAmenitiesID", "RoomAmenitiesRoomID");
                });

            modelBuilder.Entity("AsyncInn.Models.Hotel", b =>
                {
                    b.HasOne("AsyncInn.Models.HotelRoom")
                        .WithMany("Hotel")
                        .HasForeignKey("HotelRoomHotelID", "HotelRoomRoomNumber");
                });

            modelBuilder.Entity("AsyncInn.Models.Room", b =>
                {
                    b.HasOne("AsyncInn.Models.HotelRoom")
                        .WithMany("RoomLayout")
                        .HasForeignKey("HotelRoomHotelID", "HotelRoomRoomNumber");

                    b.HasOne("AsyncInn.Models.RoomAmenities")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomAmenitiesAmenitiesID", "RoomAmenitiesRoomID");
                });
#pragma warning restore 612, 618
        }
    }
}
