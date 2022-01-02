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
    public class HotelsRepositoryImp : IHotelsRepository
    {
        private ApplicationDbContext _context;

        public HotelsRepositoryImp(ApplicationDbContext context)
        {
            _context = context;
        }

        public Hotel AddNew(Hotel item)
        {
            _context.Hotel.Add(item);
            _context.SaveChanges();
            return item;
        }

        public bool CheckIfExistsById(int id)
        {
            return _context.Hotel.Any(e => e.HotelId == id);
        }

        public Hotel DeleteOneById(int id)
        {
            var hotel = _context.Hotel.FirstOrDefault(m => m.HotelId == id);
            _context.Hotel.Remove(hotel);
            _context.SaveChanges();
            return hotel;
        }

        public IList<Hotel> FindAll()
        {
            return _context.Hotel.ToList();
        }

        public Hotel FindOneById(int id)
        {
            return _context.Hotel.Include("HotelAttractions").Include("HotelDescriptions").Include("PhotosUrls").FirstOrDefault(m => m.HotelId == id);
        }

        public Hotel UpdateOne(Hotel item)
        {
            _context.Update(item);
            _context.SaveChanges();
            return item;
        }

        public dynamic GetManyByPageSizeAndOffset(int pageSize, int startIndex = -1)
        {
            var dbResults = _context.Hotel.Include("HotelAttractions").Include("HotelDescriptions").Include("PhotosUrls");
            dynamic results = new ExpandoObject();
            results.results = dbResults.ToList().Skip(startIndex).Take(pageSize);
            results.amount = dbResults.ToList().Count();
            if (startIndex == -1)
            {
                results.results = dbResults.ToList();
            }
            return results;
        }
    }
}
