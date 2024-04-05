using Hotel_Management_System.Models;

namespace Hotel_Management_System.ViewModels
{
    public class AdminViewModel
    {
        public string SelectedTable { get; set; }
        public IEnumerable<RegisterModel> Users { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
        public IEnumerable<EventReservation> EventReservations { get; set; }
    }
}
