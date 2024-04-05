using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class Room
    {
        [Key] // Define the primary key
        public int Id { get; set; } // Assuming the primary key is an integer, adjust it accordingly if it's a different type

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
    }
}
