using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Holidayaro.Data;
using Holidayaro.Models;

namespace Holidayaro.Controllers
{
    public class HotelDescriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelDescriptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HotelDescriptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.HotelDescription.ToListAsync());
        }

        // GET: HotelDescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelDescription = await _context.HotelDescription
                .FirstOrDefaultAsync(m => m.HotelDescriptionId == id);
            if (hotelDescription == null)
            {
                return NotFound();
            }

            return View(hotelDescription);
        }

        // GET: HotelDescriptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HotelDescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelDescriptionId,HotelId,Name")] HotelDescription hotelDescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelDescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotelDescription);
        }

        // GET: HotelDescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelDescription = await _context.HotelDescription.FindAsync(id);
            if (hotelDescription == null)
            {
                return NotFound();
            }
            return View(hotelDescription);
        }

        // POST: HotelDescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HotelDescriptionId,HotelId,Name")] HotelDescription hotelDescription)
        {
            if (id != hotelDescription.HotelDescriptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelDescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelDescriptionExists(hotelDescription.HotelDescriptionId))
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
            return View(hotelDescription);
        }

        // GET: HotelDescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelDescription = await _context.HotelDescription
                .FirstOrDefaultAsync(m => m.HotelDescriptionId == id);
            if (hotelDescription == null)
            {
                return NotFound();
            }

            return View(hotelDescription);
        }

        // POST: HotelDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelDescription = await _context.HotelDescription.FindAsync(id);
            _context.HotelDescription.Remove(hotelDescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelDescriptionExists(int id)
        {
            return _context.HotelDescription.Any(e => e.HotelDescriptionId == id);
        }
    }
}
