using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Holidayaro.Data;
using Holidayaro.Models;
using Microsoft.AspNetCore.Authorization;

namespace Holidayaro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosUrlsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PhotosUrlsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PhotosUrls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotosUrl>>> GetPhotosUrl()
        {
            return await _context.PhotosUrl.ToListAsync();
        }

        // GET: api/PhotosUrls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhotosUrl>> GetPhotosUrl(int id)
        {
            var photosUrl = await _context.PhotosUrl.FindAsync(id);

            if (photosUrl == null)
            {
                return NotFound();
            }

            return photosUrl;
        }

        // PUT: api/PhotosUrls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutPhotosUrl(int id, PhotosUrl photosUrl)
        {
            if (id != photosUrl.PhotosUrlId)
            {
                return BadRequest();
            }

            _context.Entry(photosUrl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotosUrlExists(id))
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

        // POST: api/PhotosUrls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PhotosUrl>> PostPhotosUrl(PhotosUrl photosUrl)
        {
            _context.PhotosUrl.Add(photosUrl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhotosUrl", new { id = photosUrl.PhotosUrlId }, photosUrl);
        }

        // DELETE: api/PhotosUrls/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePhotosUrl(int id)
        {
            var photosUrl = await _context.PhotosUrl.FindAsync(id);
            if (photosUrl == null)
            {
                return NotFound();
            }

            _context.PhotosUrl.Remove(photosUrl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhotosUrlExists(int id)
        {
            return _context.PhotosUrl.Any(e => e.PhotosUrlId == id);
        }
    }
}
