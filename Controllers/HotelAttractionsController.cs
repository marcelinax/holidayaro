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
    public class HotelAttractionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HotelAttractionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HotelAttractions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelAttraction>>> GetHotelAttraction()
        {
            return await _context.HotelAttraction.ToListAsync();
        }

        // GET: api/HotelAttractions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelAttraction>> GetHotelAttraction(int id)
        {
            var hotelAttraction = await _context.HotelAttraction.FindAsync(id);

            if (hotelAttraction == null)
            {
                return NotFound();
            }

            return hotelAttraction;
        }

        // PUT: api/HotelAttractions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelAttraction(int id, HotelAttraction hotelAttraction)
        {
            if (id != hotelAttraction.HotelAttractionId)
            {
                return BadRequest();
            }

            _context.Entry(hotelAttraction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelAttractionExists(id))
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

        // POST: api/HotelAttractions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelAttraction>> PostHotelAttraction(HotelAttraction hotelAttraction)
        {
            _context.HotelAttraction.Add(hotelAttraction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelAttraction", new { id = hotelAttraction.HotelAttractionId }, hotelAttraction);
        }

        // DELETE: api/HotelAttractions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelAttraction(int id)
        {
            var hotelAttraction = await _context.HotelAttraction.FindAsync(id);
            if (hotelAttraction == null)
            {
                return NotFound();
            }

            _context.HotelAttraction.Remove(hotelAttraction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelAttractionExists(int id)
        {
            return _context.HotelAttraction.Any(e => e.HotelAttractionId == id);
        }
    }
}
