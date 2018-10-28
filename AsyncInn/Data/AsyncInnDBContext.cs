using AsyncInn.Models;
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

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Async Inn",
                    Address = "123 Async St.",
                    Phone = "123-456-7890"
                },
                new Hotel
                {
                    ID = 2,
                    Name = "Hyatt",
                    Address = "123 Hyatt St.",
                    Phone = "281-456-7890"
                },
                new Hotel
                {
                    ID = 3,
                    Name = "Hilton",
                    Address = "123 Hilton St.",
                    Phone = "206-927-2846"
                },
                new Hotel
                {
                    ID = 4,
                    Name = "Four Seasaons",
                    Address = "123 Season St.",
                    Phone = "294-628-1846"
                },
                new Hotel
                {
                    ID = 5,
                    Name = "Westin",
                    Address = "123 Westin St.",
                    Phone = "294-194-1847"
                }
                );

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "Seattle Snooze",
                    Layout = (Layout)1
                },
                new Room
                {
                    ID = 2,
                    Name = "Seattle Skip",
                    Layout = (Layout)2
                },
                new Room
                {
                    ID = 3,
                    Name = "Chicago Snooze",
                    Layout = (Layout)3
                },
                new Room
                {
                    ID = 4,
                    Name = "Chicago Skip",
                    Layout = (Layout)1
                },
                new Room
                {
                    ID = 5,
                    Name = "Clown Nightmare",
                    Layout = (Layout)2
                },
                new Room
                {
                    ID = 6,
                    Name = "Parrot Paradise",
                    Layout = (Layout)3
                }
                );
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
    }
}
