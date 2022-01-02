using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Holidayaro.Data;
using Holidayaro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Holidayaro.Repositories;

namespace Holidayaro.Controllers

{
    public class MyReservationsController : Controller
    {
        private readonly IReservationsRepository _reservationsRepository;

        public MyReservationsController(IReservationsRepository reservationsRepository)
        {
            _reservationsRepository = reservationsRepository;
        }

        public IActionResult Index(string token = "")
        {

            var myReservations = _reservationsRepository.GetReservationsByToken(token);
            var myStatuses = _reservationsRepository.GetStatuesByToken(token, myReservations);
            ViewBag.MyReservations = myReservations;
            ViewBag.MyStatuses = myStatuses;
            return View();
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = _reservationsRepository.FindOneById((int)id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation =  _reservationsRepository.FindOneById((int)id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _reservationsRepository.DeleteOneById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _reservationsRepository.CheckIfExistsById(id);
        }
    }
}
