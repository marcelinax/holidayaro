using Holidayaro.Data;
using Holidayaro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holidayaro.Repositories
{
    public class HotelAttractionsRepositoryImp : IRepository<HotelAttraction>
    {
        private ApplicationDbContext _context;

        public HotelAttractionsRepositoryImp(ApplicationDbContext context)
        {
            _context = context;
        }
        public HotelAttraction AddNew(HotelAttraction hotelAttraction)
        {
            _context.HotelAttraction.Add(hotelAttraction);
            _context.SaveChanges();
            return hotelAttraction;
        }

        public bool CheckIfExistsById(int id)
        {
            return _context.HotelAttraction.Any(e => e.HotelAttractionId == id);
        }

        public HotelAttraction DeleteOneById(int id)
        {
            var hotelAttraction =  _context.HotelAttraction.Find(id);
            _context.HotelAttraction.Remove(hotelAttraction);
            _context.SaveChanges();
            return hotelAttraction;
        }

        public IList<HotelAttraction> FindAll()
        {
            return  _context.HotelAttraction.ToList();
        }

        public HotelAttraction FindOneById(int id)
        {
            var hotelAttraction =  _context.HotelAttraction.Find(id);
            return hotelAttraction;
        }

        public HotelAttraction UpdateOne(HotelAttraction hotelAttraction)
        {
            _context.Entry(hotelAttraction).State = EntityState.Modified;
            _context.SaveChanges();
            return hotelAttraction;
        }
    }
}
