using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;

namespace AsyncInn.Controllers
{
    public class HotelRoomsController : Controller
    {
        private readonly AsyncInnDBContext _context;

        public HotelRoomsController(AsyncInnDBContext context)
        {
            _context = context;
        }

        // GET: HotelRooms
        public async Task<IActionResult> Index()
        {
            return View(await _context.HotelRooms.ToListAsync());
        }

        // GET: HotelRooms/Details/5
        public async Task<IActionResult> Details(int HotelID, int RoomNumber)
        {
            var hotelRoom = await _context.HotelRooms
                .FirstOrDefaultAsync(m => m.HotelID == HotelID && m.RoomNumber == RoomNumber);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // GET: HotelRooms/Create
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name");
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name");
            return View();
        }

        // POST: HotelRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            Hotel checkHotel = await _context.Hotels.FirstOrDefaultAsync(x => x.ID == hotelRoom.HotelID);
            Room checkRoom = await _context.Rooms.FirstOrDefaultAsync(x => x.ID == hotelRoom.RoomID);

            if (checkHotel == null || checkRoom == null)
            {
                string error = "Invalid hotel/room id";
                return View(error);
            }
            else if (ModelState.IsValid)
            {
                _context.Add(hotelRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "ID", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "ID", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // GET: HotelRooms/Edit/5
        public async Task<IActionResult> Edit(int HotelID, int RoomNumber)
        {
            var hotelRoom = await _context.HotelRooms
                .FirstOrDefaultAsync(m => m.HotelID == HotelID && m.RoomNumber == RoomNumber);
            if (hotelRoom == null)
            {
                return NotFound();
            }
            return View(hotelRoom);
        }

        // POST: HotelRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int HotelID, int RoomNumber, [Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (HotelID != hotelRoom.HotelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelRoomExists(hotelRoom.HotelID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hotelRoom);
        }

        // GET: HotelRooms/Delete/5
        public async Task<IActionResult> Delete(int HotelID, int RoomNumber)
        {
            var hotelRoom = await _context.HotelRooms
                .FirstOrDefaultAsync(m => m.HotelID == HotelID && m.RoomNumber == RoomNumber);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // POST: HotelRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int HotelID, int RoomNumber)
        {
            var hotelRoom = await _context.HotelRooms.FindAsync(HotelID, RoomNumber);
            _context.HotelRooms.Remove(hotelRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelRoomExists(int id)
        {
            return _context.HotelRooms.Any(e => e.HotelID == id);
        }
    }
}
