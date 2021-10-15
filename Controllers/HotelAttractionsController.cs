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
    public class HotelAttractionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelAttractionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HotelAttractions
        public async Task<IActionResult> Index()
        {
            return View(await _context.HotelAttraction.ToListAsync());
        }

        // GET: HotelAttractions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelAttraction = await _context.HotelAttraction
                .FirstOrDefaultAsync(m => m.HotelAttractionId == id);
            if (hotelAttraction == null)
            {
                return NotFound();
            }

            return View(hotelAttraction);
        }

        // GET: HotelAttractions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HotelAttractions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelAttractionId,HotelId,Name")] HotelAttraction hotelAttraction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelAttraction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotelAttraction);
        }

        // GET: HotelAttractions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelAttraction = await _context.HotelAttraction.FindAsync(id);
            if (hotelAttraction == null)
            {
                return NotFound();
            }
            return View(hotelAttraction);
        }

        // POST: HotelAttractions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HotelAttractionId,HotelId,Name")] HotelAttraction hotelAttraction)
        {
            if (id != hotelAttraction.HotelAttractionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelAttraction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelAttractionExists(hotelAttraction.HotelAttractionId))
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
            return View(hotelAttraction);
        }

        // GET: HotelAttractions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelAttraction = await _context.HotelAttraction
                .FirstOrDefaultAsync(m => m.HotelAttractionId == id);
            if (hotelAttraction == null)
            {
                return NotFound();
            }

            return View(hotelAttraction);
        }

        // POST: HotelAttractions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelAttraction = await _context.HotelAttraction.FindAsync(id);
            _context.HotelAttraction.Remove(hotelAttraction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelAttractionExists(int id)
        {
            return _context.HotelAttraction.Any(e => e.HotelAttractionId == id);
        }
    }
}
