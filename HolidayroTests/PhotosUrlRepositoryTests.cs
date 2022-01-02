using Holidayaro.Data;
using Holidayaro.Models;
using Holidayaro.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace HolidayroTests
{
    [TestClass]
    public class PhotosUrlRepositoryTests
    {
        ApplicationDbContext _context;

        public PhotosUrlRepositoryTests()
        {
            DbContextOptionsBuilder<Holidayaro.Data.ApplicationDbContext> dbOptions = new DbContextOptionsBuilder<Holidayaro.Data.ApplicationDbContext>()
                .UseInMemoryDatabase(
                    Guid.NewGuid().ToString()
                );

            _context = new ApplicationDbContext(dbOptions.Options);
        }


        [TestMethod]
        public void ShouldCreatePhotoUrl()
        {
            // Arrange
            PhotosUrlsRepositoryImp _repository = new PhotosUrlsRepositoryImp(_context);
            PhotosUrl newPhotoUrl = new PhotosUrl { PhotoUrl = "http://google.pl/super_projekt.png" };

            // Act
            _repository.AddNew(newPhotoUrl);

            // Assert
            Assert.AreEqual(_context.PhotosUrl.ToList().Count, 1);
        }

        [TestMethod]
        public void ShouldReturnAllPhotoUrls()
        {
            // Arrange
            PhotosUrlsRepositoryImp _repository = new PhotosUrlsRepositoryImp(_context);
            PhotosUrl newPhotoUrl1 = new PhotosUrl { PhotoUrl = "http://google.pl/super_projekt.png" };
            PhotosUrl newPhotoUrl2 = new PhotosUrl { PhotoUrl = "http://google.pl/super_projekt.png" };
            PhotosUrl newPhotoUrl3 = new PhotosUrl { PhotoUrl = "http://google.pl/super_projekt.png" };
            PhotosUrl newPhotoUrl4 = new PhotosUrl { PhotoUrl = "http://google.pl/super_projekt.png" };

            // Act
            _context.PhotosUrl.Add(newPhotoUrl1);
            _context.PhotosUrl.Add(newPhotoUrl2);
            _context.PhotosUrl.Add(newPhotoUrl3);
            _context.PhotosUrl.Add(newPhotoUrl4);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(_repository.FindAll().Count, 4);
        }

        [TestMethod]
        public void ShouldRemovePhotoUrl()
        {
            // Arrange
            PhotosUrlsRepositoryImp _repository = new PhotosUrlsRepositoryImp(_context);
            PhotosUrl newPhotoUrl = new PhotosUrl { PhotoUrl = "http://google.pl/super_projekt.png" };

            // Act
            var createdPhotoUrl = _context.PhotosUrl.Add(newPhotoUrl);
            _context.SaveChanges();

            _repository.DeleteOneById(createdPhotoUrl.Entity.PhotosUrlId);

            // Assert
            Assert.AreEqual(_context.PhotosUrl.ToList().Count, 0);
        }

        [TestMethod]
        public void ShouldFindOnePhotoUrlById()
        {
            // Arrange
            PhotosUrlsRepositoryImp _repository = new PhotosUrlsRepositoryImp(_context);
            PhotosUrl newPhotoUrl = new PhotosUrl { PhotoUrl = "http://google.pl/super_projekt.png" };

            // Act
            var createdPhotoUrl = _context.PhotosUrl.Add(newPhotoUrl);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(_repository.FindOneById(createdPhotoUrl.Entity.PhotosUrlId).PhotosUrlId, createdPhotoUrl.Entity.PhotosUrlId);
        }

        [TestMethod]
        public void ShouldCheckIfPhotoUrlExists()
        {
            // Arrange
            PhotosUrlsRepositoryImp _repository = new PhotosUrlsRepositoryImp(_context);
            PhotosUrl newPhotoUrl = new PhotosUrl { PhotoUrl = "http://google.pl/super_projekt.png" };

            // Act
            var createdPhotoUrl = _context.PhotosUrl.Add(newPhotoUrl);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(_repository.CheckIfExistsById(createdPhotoUrl.Entity.PhotosUrlId), true);
            Assert.AreEqual(_repository.CheckIfExistsById(2), false);
        }

        [TestMethod]
        public void ShouldUpdatePhotoUrl()
        {
            // Arrange
            PhotosUrlsRepositoryImp _repository = new PhotosUrlsRepositoryImp(_context);
            PhotosUrl newPhotoUrl = new PhotosUrl { PhotoUrl = "http://google.pl/super_projekt.png" };

            // Act
            var createdPhotoUrl = _context.PhotosUrl.Add(newPhotoUrl);
            _context.SaveChanges();

            var photoUrl = createdPhotoUrl.Entity;
            photoUrl.PhotoUrl = "testingtesting";
            _repository.UpdateOne(photoUrl);

            // Assert
            Assert.AreNotEqual(_context.PhotosUrl.ToList().Where(i => i.PhotosUrlId == photoUrl.PhotosUrlId).First().PhotoUrl, "http://google.pl/super_projekt.png");
        }
    }
}
