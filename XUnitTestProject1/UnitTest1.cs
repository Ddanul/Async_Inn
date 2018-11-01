using AsyncInn.Data;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void CanGetHotelName()
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

                hotel.Name = "what?";
                ////Act
                //var hotelName = await context.Hotels.FirstOrDefaultAsync(x => x.Name == hotel.Name);

                //Assert
                Assert.Equal("what?", hotel.Name);
            }

            //Assert
            //make sure the name matches what you setup in the arrange.
        }
    }
}
