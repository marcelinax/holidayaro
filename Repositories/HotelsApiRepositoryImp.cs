using Holidayaro.Data;
using Holidayaro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holidayaro.Repositories
{
    public class HotelsApiRepositoryImp : IRepository<Hotel>
    {
        private ApplicationDbContext _context;

        public HotelsApiRepositoryImp(ApplicationDbContext context)
        {
            _context = context;
        }
        public Hotel AddNew(Hotel hotel)
        {
            _context.Hotel.Add(hotel);
            _context.SaveChanges();
            return hotel;
        }

        public bool CheckIfExistsById(int id)
        {
            return _context.Hotel.Any(e => e.HotelId == id);
        }

        public Hotel DeleteOneById(int id)
        {
            var hotel =  _context.Hotel.Find(id);
            _context.Hotel.Remove(hotel);
            _context.SaveChanges();
            return hotel;
        }

        public IList<Hotel> FindAll()
        {
            return _context.Hotel.Include("HotelAttractions").Include("HotelDescriptions").Include("PhotosUrls").ToList();
        }

        public Hotel FindOneById(int id)
        {
            return _context.Hotel.Find(id);
        }

        public Hotel UpdateOne(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            _context.SaveChanges();
            return hotel;
        }
    }
}
