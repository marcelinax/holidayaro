using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Holidayaro.Data;
using Holidayaro.Models;

namespace Holidayaro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelDescriptionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HotelDescriptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HotelDescriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDescription>>> GetHotelDescription()
        {
            return await _context.HotelDescription.ToListAsync();
        }

        // GET: api/HotelDescriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDescription>> GetHotelDescription(int id)
        {
            var hotelDescription = await _context.HotelDescription.FindAsync(id);

            if (hotelDescription == null)
            {
                return NotFound();
            }

            return hotelDescription;
        }

        // PUT: api/HotelDescriptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelDescription(int id, HotelDescription hotelDescription)
        {
            if (id != hotelDescription.HotelDescriptionId)
            {
                return BadRequest();
            }

            _context.Entry(hotelDescription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelDescriptionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HotelDescriptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelDescription>> PostHotelDescription(HotelDescription hotelDescription)
        {
            _context.HotelDescription.Add(hotelDescription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelDescription", new { id = hotelDescription.HotelDescriptionId }, hotelDescription);
        }

        // DELETE: api/HotelDescriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelDescription(int id)
        {
            var hotelDescription = await _context.HotelDescription.FindAsync(id);
            if (hotelDescription == null)
            {
                return NotFound();
            }

            _context.HotelDescription.Remove(hotelDescription);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelDescriptionExists(int id)
        {
            return _context.HotelDescription.Any(e => e.HotelDescriptionId == id);
        }
    }
}
