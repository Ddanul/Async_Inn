using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    interface IRooms
    {
        //Create
        Task CreateRoom(Room room);
        //Read
        Task<Room> GetRoom(int? id);

        Task<IEnumerable<Room>> GetRoomsAsync();
        //Update
        Task UpdateRoomAsync(Room room);
        //Delete
        Task DeleteRoomAsync(int id);
    }
}
