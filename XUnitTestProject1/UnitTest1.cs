using AsyncInn.Data;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        /// <summary>
        /// Test can get hotel name
        /// </summary>
        [Fact]
        public void CanGetHotelName()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "MyCourse";

            Assert.Equal("MyCourse", hotel.Name);
        }

        /// <summary>
        /// test can set hotel name
        /// </summary>
        [Fact]
        public void SetHotelName()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "Wizard Inn";
            hotel.Address = "123 wiz st.";
            hotel.Phone = "123455678";

            Assert.Equal("Wizard Inn", hotel.Name);
        }

        /// <summary>
        /// test can create, read, update, and delete hotel in db
        /// </summary>
        [Fact]
        public async void CrudHotelInDB()
        {
            //Arrange
            //setup our DB
            //set values
            
            DbContextOptions<AsyncInnDBContext> options = 
                new DbContextOptionsBuilder<AsyncInnDBContext>()
                .UseInMemoryDatabase("DbCanSave").Options;

            //Act
            //creating a variable that "gets" the name
            using (AsyncInnDBContext context = new AsyncInnDBContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.Name = "Test Hotel";
                hotel.Address = "123 test";
                hotel.Phone = "1234567";
                
                ////Act

                context.Hotels.Add(hotel);
                context.SaveChanges();

                var hotelName = await context.Hotels.FirstOrDefaultAsync(x => x.Name == hotel.Name);

                //Assert
                Assert.Equal("Test Hotel", hotelName.Name);

                //UPDATE
                hotel.Name = "Update Hotel";
                context.Hotels.Update(hotel);
                context.SaveChanges();

                var updatedHotel = await context.Hotels.FirstOrDefaultAsync(x => x.Name == hotel.Name);

                Assert.Equal("Update Hotel", updatedHotel.Name);

                //DELETE
                context.Hotels.Remove(hotel);
                context.SaveChanges();

                var deletedHotel = await context.Hotels.FirstOrDefaultAsync(x => x.Name == hotel.Name);

                Assert.True(deletedHotel==null);
            }

            //Assert
            //make sure the name matches what you setup in the arrange.
        }

        /// <summary>
        /// Test can get Room name
        /// </summary>
        [Fact]
        public void CanGetRoomName()
        {
            Room room = new Room();
            room.Name = "New Room";

            Assert.Equal("New Room", room.Name);
        }

        /// <summary>
        /// test can set room name
        /// </summary>
        [Fact]
        public void SetRoomName()
        {
            Room room = new Room();
            room.Layout = Layout.OneBedroom;
            room.Name = "Joss Stone";
            
            Assert.Equal("Joss Stone", room.Name);
        }

        /// <summary>
        /// test can create, save, update, and delete a room in db
        /// </summary>
        [Fact]
        public async void CrudRoomInDB()
        {
            //Arrange
            //setup our DB
            //set values

            DbContextOptions<AsyncInnDBContext> options =
                new DbContextOptionsBuilder<AsyncInnDBContext>()
                .UseInMemoryDatabase("DbCanSave").Options;

            //Act
            //creating a variable that "gets" the name
            using (AsyncInnDBContext context = new AsyncInnDBContext(options))
            {
                Room room = new Room();
                room.Layout = Layout.OneBedroom;
                room.Name = "Joss Stone";

                ////Act

                context.Rooms.Add(room);
                context.SaveChanges();

                var roomName = await context.Rooms.FirstOrDefaultAsync(x => x.Name == room.Name);

                //Assert
                Assert.Equal("Joss Stone", roomName.Name);

                //UPDATE
                room.Name = "Emma Stone";

                context.Update(room);
                context.SaveChanges();

                var updatedRoom = await context.Rooms.FirstOrDefaultAsync(x => x.Name == "Emma Stone");

                Assert.Equal("Emma Stone", updatedRoom.Name);

                //DELETE
                context.Remove(room);
                context.SaveChanges();

                var deletedRoom = await context.Rooms.FirstOrDefaultAsync(x => x.Name == "Emma Stone");

                Assert.True(deletedRoom == null);
            }

            //Assert
            //make sure the name matches what you setup in the arrange.
        }

        /// <summary>
        /// Test can get amenity name
        /// </summary>
        [Fact]
        public void CanGetAmenityName()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "Coffee Maker";

            Assert.Equal("Coffee Maker", amenity.Name);
        }

        /// <summary>
        /// test can set amenity name
        /// </summary>
        [Fact]
        public void SetAmenityName()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "Coffee Maker";
      
            Assert.Equal("Coffee Maker", amenity.Name);
        }

        /// <summary>
        /// test can create, save, update, delete amenity in db
        /// </summary>
        [Fact]
        public async void CrudAmenityInDB()
        {
            //Arrange
            //setup our DB
            //set values

            DbContextOptions<AsyncInnDBContext> options =
                new DbContextOptionsBuilder<AsyncInnDBContext>()
                .UseInMemoryDatabase("DbCanSave").Options;

            //Act
            //creating a variable that "gets" the name
            using (AsyncInnDBContext context = new AsyncInnDBContext(options))
            {
                Amenities amenity = new Amenities();
                amenity.Name = "Coffee Maker";

                ////Act

                context.Amenities.Add(amenity);
                context.SaveChanges();

                var amenityName = await context.Amenities.FirstOrDefaultAsync(x => x.Name == amenity.Name);

                //Assert
                Assert.Equal("Coffee Maker", amenityName.Name);

                //UPDATE

                amenity.Name = "Dog Spa";

                context.Update(amenity);
                context.SaveChanges();

                var updatedAmenity = await context.Amenities.FirstOrDefaultAsync(x => x.Name == "Dog Spa");

                Assert.Equal("Dog Spa", updatedAmenity.Name);

                //DELETE

                context.Remove(amenity);
                context.SaveChanges();

                var deletedAmenity = await context.Amenities.FirstOrDefaultAsync(x => x.Name == "Dog Spa");

                Assert.True(deletedAmenity == null);
            }

            //Assert
            //make sure the name matches what you setup in the arrange.
        }
    }
}
