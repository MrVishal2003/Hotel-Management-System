// Controllers/HomeController.cs

using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using YourAppName.Data;

namespace Hotel_Management_System.Controllers
{
    public class HomeController : Controller
    {
       private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
   
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            
        }
       
        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Room()
        {
            return View();
        }
        public IActionResult Gallary()
        {
            return View();
        }
        public IActionResult Entertainment()
        {
            return View();
        }
        public IActionResult Dinning()
        {
            return View();
        }
        public IActionResult Events()
        {
            return View();
        }

        [HttpGet]
        [HttpPost]
        public IActionResult BookRoom(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
               
                _context.Reservations.Add(reservation);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservation);
        }

        public IActionResult BookEvent(EventReservation event_reservation)
        {
            if (ModelState.IsValid)
            {
                _context.EventReservations.Add(event_reservation);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(event_reservation);
          
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(RegisterModel abc)
        {
            var users = _context.Users.FirstOrDefault(u => u.Email == abc.Email && u.Password == abc.Password);
            if (users != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("LoginError", "Your Email or password is incorrect");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(RegisterModel abc)
        {
            if (!ModelState.IsValid)
            {
                // If validation fails, return the same view with validation errors
                return View(abc);
            }
            
            _context.Users.Add(abc);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            // Perform logout logic here, such as clearing authentication cookies
            await HttpContext.SignOutAsync();

            // Redirect to the login page
            return RedirectToAction("Login", "Home"); // Replace "Home" with your actual controller name
        }
        public IActionResult Terms()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
