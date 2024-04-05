using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        // This is just a sample data structure to represent rooms.
        private List<Room> rooms = new List<Room>
        {
            new Room { Id = 1, Name = "Single Room", Price = 25000, Capacity = 1 },
            new Room { Id = 2, Name = "Double Room", Price = 50000, Capacity = 2 },
            new Room { Id = 3, Name = "Deluxe Bed", Price = 80000, Capacity = 1 },
            new Room { Id = 4, Name = "Twin Room", Price = 38000, Capacity = 2 },
            new Room { Id = 5, Name = "Villa", Price = 100000, Capacity = 4 }
        };

        // GET: api/room
        [HttpGet]
        public IActionResult GetRooms()
        {
            return Ok(rooms);
        }

        // GET: api/room/1
        [HttpGet("{id}")]
        public IActionResult GetRoomById(int id)
        {
            var room = rooms.FirstOrDefault(r => r.Id == id);

            if (room == null)
            {
                return NotFound("Room not found.");
            }

            return Ok(room);
        }
    }

    // Sample Room class
    public class Room
    {
        public int Id { get; set; } // Primary key
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
    }
}
