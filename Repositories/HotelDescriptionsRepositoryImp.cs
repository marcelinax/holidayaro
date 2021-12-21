using Holidayaro.Data;
using Holidayaro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holidayaro.Repositories
{
    public class HotelDescriptionsRepositoryImp : IRepository<HotelDescription>
    {
        private ApplicationDbContext _context;

        public HotelDescriptionsRepositoryImp(ApplicationDbContext context)
        {
            _context = context;
        }
        public HotelDescription AddNew(HotelDescription hotelDescription)
        {
            _context.HotelDescription.Add(hotelDescription);
            _context.SaveChanges();
            return hotelDescription;
        }

        public bool CheckIfExistsById(int id)
        {
            return _context.HotelDescription.Any(e => e.HotelDescriptionId == id);
        }

        public HotelDescription DeleteOneById(int id)
        {
            var hotelDescription =  _context.HotelDescription.Find(id);
            _context.HotelDescription.Remove(hotelDescription);
             _context.SaveChanges();
            return hotelDescription;
        }

        public IList<HotelDescription> FindAll()
        {
            return  _context.HotelDescription.ToList();
        }

        public HotelDescription FindOneById(int id)
        {
            return _context.HotelDescription.Find(id);
        }

        public HotelDescription UpdateOne(HotelDescription hotelDescription)
        {
            _context.Entry(hotelDescription).State = EntityState.Modified;
            _context.SaveChanges();
            return hotelDescription;
        }
    }
}
