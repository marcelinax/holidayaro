using Holidayaro.Data;
using Holidayaro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Holidayaro.Repositories
{
    public class ReservationRepositoryImp : IReservationsRepository
    {
        private ApplicationDbContext _context;
        public ReservationRepositoryImp(ApplicationDbContext context)
        {
            _context = context;
        }


        public Reservation AddNew(Reservation reservation)
        {
            _context.Reservation.Add(reservation);
            _context.SaveChanges();
            return reservation;
        }

        public Reservation DeleteOneById(int id)
        {
            var reservation = _context.Reservation.Find(id);
            _context.Reservation.Remove(reservation);
            _context.SaveChanges();
            return reservation;
        }

        public bool CheckIfExistsById(int id)
        {
            return _context.Reservation.Any(e => e.ReservationId == id);
        }

        public Reservation FindOneById(int id)
        {
            return _context.Reservation.Include(r => r.Hotel).FirstOrDefault(m => m.ReservationId == id);
        }

        public IList<Reservation> FindAll()
        {
            return _context.Reservation.ToList();
        }

        public Reservation UpdateOne(Reservation reservation)
        {
            _context.Entry(reservation).State = EntityState.Modified;
            _context.SaveChanges();
            return reservation;
        }

        public List<Reservation> GetReservationsByToken(string token = "")
        {
            var reservations = _context.Reservation.Include(r => r.Hotel).Include(r => r.Hotel.PhotosUrls).ToList();
            return reservations.FindAll(r => r.UserToken == token);
        }

        public List<bool> GetStatuesByToken(string token, List<Reservation> reservations)
        {
            var payments = _context.Payment.ToList();
            List<Boolean> myStatuses = new List<Boolean>();
            foreach (var reservation in reservations)
            {
                var status = payments.FindAll(p => p.ReservationId == reservation.ReservationId).Count > 0;
                myStatuses.Add(status);
            }
            return myStatuses;
        }
    }
}
