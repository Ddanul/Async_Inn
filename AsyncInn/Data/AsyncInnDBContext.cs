﻿using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDBContext : DbContext
    {
        public AsyncInnDBContext(DbContextOptions<AsyncInnDBContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoom>().HasKey(
                hr => new { hr.HotelID, hr.RoomNumber }
                );

            modelBuilder.Entity<RoomAmenities>().HasKey(
                ra => new { ra.AmenitiesID, ra.RoomID }
                );
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
    }
}
