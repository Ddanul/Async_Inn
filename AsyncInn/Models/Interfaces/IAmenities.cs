using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenities
    {
        //Create
        Task CreateAmenity(Amenities amenity);
        //Read
        Task<Amenities> GetAmenity(int? id);

        Task<IEnumerable<Amenities>> GetAmenities();
        //Update
        Task UpdateAmenities(Amenities amenity);
        //Delete
        Task DeleteAmenities(int id);
    }
}
