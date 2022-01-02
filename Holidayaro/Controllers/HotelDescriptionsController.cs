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
    public class HotelDescriptionsController : ControllerBase
    {
        private readonly IRepository<HotelDescription> _hotelDescriptionsRepository;

        public HotelDescriptionsController(IRepository<HotelDescription> hotelDescriptionsRepository)
        {
            _hotelDescriptionsRepository = hotelDescriptionsRepository;
        }

        [HttpGet]
        public IEnumerable<HotelDescription> GetHotelDescription()
        {
            return _hotelDescriptionsRepository.FindAll();
        }

        [HttpGet("{id}")]
        public HotelDescription GetHotelDescription(int id)
        {
            return _hotelDescriptionsRepository.FindOneById(id);
        }

        [HttpPut("{id}")]
        [Authorize]
        public HotelDescription PutHotelDescription(int id, HotelDescription hotelDescription)
        {
            return _hotelDescriptionsRepository.UpdateOne(hotelDescription);
        }

        [HttpPost]
        [Authorize]
        public ActionResult<HotelDescription> PostHotelDescription(HotelDescription hotelDescription)
        {
            HotelDescription hd = _hotelDescriptionsRepository.AddNew(hotelDescription);
            return CreatedAtAction("GetHotelDescription", new { id = hd.HotelDescriptionId }, hd);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public HotelDescription DeleteHotelDescription(int id)
        {
            return _hotelDescriptionsRepository.DeleteOneById(id);
        }

        private bool HotelDescriptionExists(int id)
        {
            return _hotelDescriptionsRepository.CheckIfExistsById(id);
        }
    }
}
