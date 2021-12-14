using Holidayaro.Data;
using Holidayaro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holidayaro.Repositories
{
    public class ReservationRepositoryImp : IRepository<Reservation>
    {
        private ApplicationDbContext _context;
        public ReservationRepositoryImp(ApplicationDbContext context)
        {
            _context = context;
        }


        public Reservation Add(Reservation reservation)
        {
            _context.Reservation.Add(reservation);
            _context.SaveChanges();
            return reservation;
        }

        public Reservation Delete(int id)
        {
            var reservation = _context.Reservation.Find(id);
            _context.Reservation.Remove(reservation);
            _context.SaveChanges();
            return reservation;
        }

        public bool Exists(int id)
        {
            return _context.Reservation.Any(e => e.ReservationId == id);
        }

        public Reservation Find(int id)
        {
            return _context.Reservation.Find(id);
        }

        public IList<Reservation> FindAll()
        {
            throw new NotImplementedException();
        }

        public Reservation Update(Reservation reservation)
        {
            _context.Entry(reservation).State = EntityState.Modified;
            _context.SaveChanges();
            return reservation;
        }
    }
}
