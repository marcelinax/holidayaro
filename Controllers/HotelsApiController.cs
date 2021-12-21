using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Holidayaro.Data;
using Holidayaro.Models;
using Holidayaro.Repositories;

namespace Holidayaro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsApiController : ControllerBase
    {
        private readonly IRepository<Hotel> _hotelsApiRepository;

        public HotelsApiController(IRepository<Hotel> hotelsApiRepository)
        {
            _hotelsApiRepository = hotelsApiRepository;
        }

        [HttpGet]
        public IEnumerable<Hotel> GetHotel()
        {
            return _hotelsApiRepository.FindAll();
        }

        [HttpGet("{id}")]
        public Hotel GetHotel(int id)
        {
            return _hotelsApiRepository.FindOneById(id);
        }

        [HttpPut("{id}")]
        public Hotel PutHotel(int id, Hotel hotel)
        {
            return _hotelsApiRepository.UpdateOne(hotel);
        }

        [HttpPost]
        public ActionResult<Hotel> PostHotel(Hotel hotel)
        {
            Hotel h = _hotelsApiRepository.AddNew(hotel);
            return CreatedAtAction("GetHotel", new { id = h.HotelId }, h);
        }

        [HttpDelete("{id}")]
        public Hotel DeleteHotel(int id)
        {
            return _hotelsApiRepository.DeleteOneById(id);
        }

        private bool HotelExists(int id)
        {
            return _hotelsApiRepository.CheckIfExistsById(id);
        }
    }
}
