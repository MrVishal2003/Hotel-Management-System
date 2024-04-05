// Data/ApplicationDbContext.cs

using Hotel_Management_System.Models;
using Hotel_Management_System.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace YourAppName.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RegisterModel> Users { get; set; }
        public DbSet<EventReservation> EventReservations {  get; set; }
        public DbSet<AdminModel> AdminCrud { get; set; }
       
    }
}
