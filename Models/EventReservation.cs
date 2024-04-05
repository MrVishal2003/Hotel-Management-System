using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class EventReservation 
    {
      
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "Check-in date is required")]
            [Display(Name = "Check-in Date")]
            public DateTime CheckInDate { get; set; }

            [Required(ErrorMessage = "Check-out date is required")]
            [Display(Name = "Check-out Date")]
            public DateTime CheckOutDate { get; set; }

            [Required(ErrorMessage = "Event is required")]
            [Display(Name = "Events")]
            public string Events { get; set; }

            [Required(ErrorMessage = "Event Place is required")]
            [Display(Name = "Event Place")]
            public string EventPlace { get; set; }

        [Required(ErrorMessage = "Number of adults is required")]
        [Display(Name = "Number of Adults")]
        public int NumberOfAdults { get; set; }

        [Required(ErrorMessage = "Number of children is required")]
        [Display(Name = "Number of Children")]
        public int NumberOfChildren { get; set; }

        [Required(ErrorMessage = " ")]
        [Display(Name = "Hall Type")]
        public string HallType { get; set; }
    }
}

