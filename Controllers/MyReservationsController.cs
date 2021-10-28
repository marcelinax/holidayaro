﻿using System;
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



namespace Holidayaro.Controllers

{
    public class MyReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MyReservations
        public async Task<IActionResult> Index(string token = "")
        {
            var reservations = await _context.Reservation.Include(r => r.Hotel).Include(r => r.Hotel.PhotosUrls).ToListAsync();
            var myReservations = reservations.FindAll(r => r.UserToken == token);
            var payments =await _context.Payment.ToListAsync();
            var myPayments = payments.FindAll(p => myReservations.FindAll(r => r.ReservationId == p.ReservationId).Count > 0);
            List<Boolean> myStatuses = new List<Boolean>();
            foreach (var reservation in myReservations) {
                var status = payments.FindAll(p => p.ReservationId == reservation.ReservationId).Count > 0;
                myStatuses.Add(status);
            }
            ViewBag.MyReservations = myReservations;
            ViewBag.MyStatuses = myStatuses;
            return View();
        }

        // GET: MyReservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .Include(r => r.Hotel)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }


        // GET: MyReservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .Include(r => r.Hotel)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: MyReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservation.FindAsync(id);
            _context.Reservation.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservation.Any(e => e.ReservationId == id);
        }
    }
}
