using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRooms
    {
        //Create
        Task CreateRoom(Room room);
        //Read
        Task<Room> GetRoom(int? id);

        Task<IEnumerable<Room>> GetRooms();
        //Update
        Task UpdateRoom(Room room);
        //Delete
        Task DeleteRoom(int id);
    }
}
