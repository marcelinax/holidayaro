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
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationsRepository _reservationRepository;

        public ReservationsController(IReservationsRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        [HttpGet]
        public  IList<Reservation> GetReservation()
        {
            return _reservationRepository.FindAll();
        }

        [HttpGet("{id}")]
        public Reservation GetReservation(int id)
        {
            return _reservationRepository.FindOneById(id);
        }

        [HttpPut("{id}")]
        public IActionResult PutReservation(int id, Reservation reservation)
        {
            _reservationRepository.UpdateOne(reservation);
            return NoContent();
        }

        [HttpPost]
        public ActionResult<Reservation> PostReservation(Reservation reservation)
        {
            Reservation r = _reservationRepository.AddNew(reservation);

            return CreatedAtAction("GetReservation", new { id = r.ReservationId }, r);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReservation(int id)
        {

            _reservationRepository.DeleteOneById(id);
            return NoContent();
        }

        private bool ReservationExists(int id)
        {
            return _reservationRepository.CheckIfExistsById(id);
        }
    }
}
