using Holidayaro.Data;
using Holidayaro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holidayaro.Repositories
{
    public class PhotosUrlsRepositoryImp : IRepository<PhotosUrl>
    {
        private ApplicationDbContext _context;

        public PhotosUrlsRepositoryImp(ApplicationDbContext context)
        {
            _context = context;
        }
        public PhotosUrl AddNew(PhotosUrl photosUrl)
        {
            _context.PhotosUrl.Add(photosUrl);
            _context.SaveChanges();
            return photosUrl;
        }

        public bool CheckIfExistsById(int id)
        {
            return _context.PhotosUrl.Any(e => e.PhotosUrlId == id);
        }

        public PhotosUrl DeleteOneById(int id)
        {
            var photosUrl = _context.PhotosUrl.Find(id);
            _context.PhotosUrl.Remove(photosUrl);
             _context.SaveChanges();
            return photosUrl;
        }

        public IList<PhotosUrl> FindAll()
        {
            return _context.PhotosUrl.ToList();
        }

        public PhotosUrl FindOneById(int id)
        {
            var photosUrl = _context.PhotosUrl.Find(id);
            return photosUrl;
        }

        public PhotosUrl UpdateOne(PhotosUrl photosUrl)
        {
            _context.Entry(photosUrl).State = EntityState.Modified;
            _context.SaveChanges();
            return photosUrl;
        }
    }
}
