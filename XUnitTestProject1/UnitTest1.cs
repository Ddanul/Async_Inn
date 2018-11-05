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
        /// test can save hotel in db
        /// </summary>
        [Fact]
        public async void SaveHotelInDB()
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
        /// test can save room in db
        /// </summary>
        [Fact]
        public async void SaveRoomInDB()
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
        /// test can save amenity in db
        /// </summary>
        [Fact]
        public async void SaveAmenityInDB()
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
            }

            //Assert
            //make sure the name matches what you setup in the arrange.
        }
    }
}
