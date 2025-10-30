using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaterServiceBookingSystem.Models;

namespace WaterServiceBookingSystem.Controllers
{
    public class ServiceBookingsController : Controller
    {
        private readonly AppDbContext _context;

        public ServiceBookingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ServiceBookings
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceBookings.ToListAsync());
        }

        // GET: ServiceBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var serviceBooking = await _context.ServiceBookings
                .FirstOrDefaultAsync(m => m.Id == id);

            if (serviceBooking == null)
                return NotFound();

            return View(serviceBooking);
        }

        // GET: ServiceBookings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceBookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerName,Email,Phone,Address,ServiceType,PreferredDate,Notes")] ServiceBooking serviceBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceBooking);
                await _context.SaveChangesAsync();

                // Redirect to Confirmation with the saved booking's ID
                return RedirectToAction("Confirmation", new { id = serviceBooking.Id });
            }

            // If invalid, reload Create page with validation errors
            return View(serviceBooking);
        }

        // GET: Confirmation Page
        public async Task<IActionResult> Confirmation(int id)
        {
            var booking = await _context.ServiceBookings.FirstOrDefaultAsync(b => b.Id == id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // GET: ServiceBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var serviceBooking = await _context.ServiceBookings.FindAsync(id);
            if (serviceBooking == null)
                return NotFound();

            return View(serviceBooking);
        }

        // POST: ServiceBookings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerName,Email,Phone,Address,ServiceType,PreferredDate,Notes")] ServiceBooking serviceBooking)
        {
            if (id != serviceBooking.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceBookingExists(serviceBooking.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }
            return View(serviceBooking);
        }

        // GET: ServiceBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var serviceBooking = await _context.ServiceBookings
                .FirstOrDefaultAsync(m => m.Id == id);

            if (serviceBooking == null)
                return NotFound();

            return View(serviceBooking);
        }

        // POST: ServiceBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceBooking = await _context.ServiceBookings.FindAsync(id);
            if (serviceBooking != null)
            {
                _context.ServiceBookings.Remove(serviceBooking);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ServiceBookingExists(int id)
        {
            return _context.ServiceBookings.Any(e => e.Id == id);
        }
    }
}