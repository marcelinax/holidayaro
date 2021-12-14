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
        private readonly IRepository<Reservation> _reservationRepository;

        public ReservationsController(IRepository<Reservation> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        // GET: api/Reservations
        [HttpGet]
        public  IList<Reservation> GetReservation()
        {
            return _reservationRepository.FindAll();
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public Reservation GetReservation(int id)
        {
            return _reservationRepository.Find(id);
        }

        // PUT: api/Reservations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutReservation(int id, Reservation reservation)
        {
            _reservationRepository.Update(reservation);
            return NoContent();
        }

        // POST: api/Reservations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Reservation> PostReservation(Reservation reservation)
        {
            Reservation r = _reservationRepository.Add(reservation);

            return CreatedAtAction("GetReservation", new { id = r.ReservationId }, r);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public IActionResult DeleteReservation(int id)
        {

            _reservationRepository.Delete(id);
            return NoContent();
        }

        private bool ReservationExists(int id)
        {
            return _reservationRepository.Exists(id);
        }
    }
}
