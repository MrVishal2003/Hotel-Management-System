using Hotel_Management_System.Models;
using Hotel_Management_System.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourAppName.Data;
using System.Linq;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AdminController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public IActionResult Admin()
    {
        var viewModel = new AdminViewModel
        {
            Users = _context.Users.ToList(),
            Reservations = _context.Reservations.ToList(),
            EventReservations = _context.EventReservations.ToList()
        };

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult AdminCrud()
    {
        // Check if the user is logged in
        if (!IsUserLoggedIn())
        {
            return RedirectToAction("Login"); // Redirect to the login page if not logged in
        }

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AdminCrud(AdminModel abc)
    {
        var users = _context.AdminCrud.FirstOrDefault(u => u.Email == abc.Email && u.Password == abc.Password);
        if (users != null)
        {
            // Set the session variable to mark the user as logged in
            _httpContextAccessor.HttpContext.Session.SetString("IsLoggedIn", "true");
            return RedirectToAction("Admin");
        }
        else
        {
            ModelState.AddModelError("LoginError", "Your Email or password is incorrect");
            return View();
        }
    }

    // GET: Admin/Edit/5
    public IActionResult Edit(int id)
    {
        var reservation = _context.Reservations.FirstOrDefault(r => r.Id == id);
        if (reservation == null)
        {
            return NotFound();
        }
        return View(reservation);
    }

    // POST: Admin/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Reservation reservation)
    {
        if (id != reservation.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(reservation);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(reservation.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Admin)); // Redirect to Admin action
        }
        return View(reservation);
    }

    // GET: Admin/Delete/5
    public IActionResult Delete(int id)
    {
        var reservation = _context.Reservations.FirstOrDefault(r => r.Id == id);
        if (reservation == null)
        {
            return NotFound();
        }
        return View(reservation);
    }

    // POST: Admin/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var reservation = _context.Reservations.Find(id);
        if (reservation == null)
        {
            return NotFound();
        }

        _context.Reservations.Remove(reservation);
        _context.SaveChanges();
        return RedirectToAction(nameof(Admin)); // Redirect to Admin action
    }

    // GET: Admin/EditEventReservation/5
    public IActionResult EditEventReservation(int id)
    {
        var eventReservation = _context.EventReservations.FirstOrDefault(e => e.Id == id);
        if (eventReservation == null)
        {
            return NotFound();
        }
        return View(eventReservation);
    }

    // POST: Admin/EditEventReservation/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditEventReservation(int id, EventReservation eventReservation)
    {
        if (id != eventReservation.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(eventReservation);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventReservationExists(eventReservation.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Admin)); // Redirect to Admin action
        }
        return View(eventReservation);
    }

    // GET: Admin/DeleteEventReservation/5
    public IActionResult DeleteEventReservation(int id)
    {
        var eventReservation = _context.EventReservations.FirstOrDefault(e => e.Id == id);
        if (eventReservation == null)
        {
            return NotFound();
        }
        return View(eventReservation);
    }

    // POST: Admin/DeleteEventReservation/5
    [HttpPost, ActionName("DeleteEventReservation")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmedEventReservation(int id)
    {
        var eventReservation = _context.EventReservations.Find(id);
        if (eventReservation == null)
        {
            return NotFound();
        }

        _context.EventReservations.Remove(eventReservation);
        _context.SaveChanges();
        return RedirectToAction(nameof(Admin)); // Redirect to Admin action
    }

    private bool IsUserLoggedIn()
    {
        // Check if the session variable IsLoggedIn is set to true
        return _httpContextAccessor.HttpContext.Session.GetString("IsLoggedIn") == "true";
    }

    private bool ReservationExists(int id)
    {
        return _context.Reservations.Any(r => r.Id == id);
    }

    private bool EventReservationExists(int id)
    {
        return _context.EventReservations.Any(e => e.Id == id);
    }
}
