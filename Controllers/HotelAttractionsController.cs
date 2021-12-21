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
using Holidayaro.Repositories;

namespace Holidayaro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class HotelAttractionsController : ControllerBase
    {
        private readonly IRepository<HotelAttraction> _hotelAttractionsRepository;

        public HotelAttractionsController(IRepository<HotelAttraction> hotelAttractionsRepository)
        {
            _hotelAttractionsRepository = hotelAttractionsRepository;
        }

        [HttpGet]
        public IEnumerable<HotelAttraction> GetHotelAttraction()
        {
            return _hotelAttractionsRepository.FindAll();
        }

        [HttpGet("{id}")]
        public  HotelAttraction GetHotelAttraction(int id)
        {
            return _hotelAttractionsRepository.FindOneById(id);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult PutHotelAttraction(int id, HotelAttraction hotelAttraction)
        {
            _hotelAttractionsRepository.UpdateOne(hotelAttraction);
            return NoContent();
        }

        [HttpPost]
        [Authorize]
        public ActionResult<HotelAttraction> PostHotelAttraction(HotelAttraction hotelAttraction)
        {
            HotelAttraction ha = _hotelAttractionsRepository.AddNew(hotelAttraction);
            return CreatedAtAction("GetHotelAttraction", new { id = ha.HotelAttractionId }, ha);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public HotelAttraction DeleteHotelAttraction(int id)
        {
            return _hotelAttractionsRepository.DeleteOneById(id);
        }

        private bool HotelAttractionExists(int id)
        {
            return _hotelAttractionsRepository.CheckIfExistsById(id);
        }
    }
}
