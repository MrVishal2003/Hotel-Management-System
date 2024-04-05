// Models/Reservation.cs

using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Check-in date is required")]
        [Display(Name = "Check-in Date")]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "Check-out date is required")]
        [Display(Name = "Check-out Date")]
        public DateTime CheckOutDate { get; set; }

        [Required(ErrorMessage = "Number of rooms is required")]
        [Display(Name = "Number of Rooms")]
        public int NumberOfRooms { get; set; }

        [Required(ErrorMessage = "Room floor is required")]
        [Display(Name = "Room Floor")]
        public int RoomFloor { get; set; }

        [Required(ErrorMessage = "Number of adults is required")]
        [Display(Name = "Number of Adults")]
        public int NumberOfAdults { get; set; }

        [Required(ErrorMessage = "Number of children is required")]
        [Display(Name = "Number of Children")]
        public int NumberOfChildren { get; set; }

        [Required(ErrorMessage = " ")]
        [Display(Name = "Room Type")]
        public string RoomType { get; set; }
    }
}