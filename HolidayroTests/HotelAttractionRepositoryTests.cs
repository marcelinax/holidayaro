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
    public class HotelAttractionRepositoryTests
    {
        ApplicationDbContext _context;

        public HotelAttractionRepositoryTests()
        {
            DbContextOptionsBuilder<Holidayaro.Data.ApplicationDbContext> dbOptions = new DbContextOptionsBuilder<Holidayaro.Data.ApplicationDbContext>()
                .UseInMemoryDatabase(
                    Guid.NewGuid().ToString()
                );

            _context = new ApplicationDbContext(dbOptions.Options);
        }


        [TestMethod]
        public void ShouldCreateHotelAttraction()
        {
            // Arrange
            HotelAttractionsRepositoryImp _repository = new HotelAttractionsRepositoryImp(_context);
            HotelAttraction newHotelAttraction = new HotelAttraction { Name = "HotelAttraction" };

            // Act
            _repository.AddNew(newHotelAttraction);

            // Assert
            Assert.AreEqual(_context.HotelAttraction.ToList().Count, 1);
        }

        [TestMethod]
        public void ShouldReturnAllHotelAttraction()
        {
            // Arrange
            HotelAttractionsRepositoryImp _repository = new HotelAttractionsRepositoryImp(_context);
            HotelAttraction newHotelAttraction1 = new HotelAttraction { Name = "HotelAttraction" };
            HotelAttraction newHotelAttraction2 = new HotelAttraction { Name = "HotelAttraction" };
            HotelAttraction newHotelAttraction3 = new HotelAttraction { Name = "HotelAttraction" };
            HotelAttraction newHotelAttraction4 = new HotelAttraction { Name = "HotelAttraction" };

            // Act
            _context.HotelAttraction.Add(newHotelAttraction1);
            _context.HotelAttraction.Add(newHotelAttraction2);
            _context.HotelAttraction.Add(newHotelAttraction3);
            _context.HotelAttraction.Add(newHotelAttraction4);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(_repository.FindAll().Count, 4);
        }

        [TestMethod]
        public void ShouldRemoveHotelAttraction()
        {
            // Arrange
            HotelAttractionsRepositoryImp _repository = new HotelAttractionsRepositoryImp(_context);
            HotelAttraction newHotelAttraction = new HotelAttraction { Name = "HotelAttraction" };

            // Act
            var createdHotelAttractionUrl = _context.HotelAttraction.Add(newHotelAttraction);
            _context.SaveChanges();

            _repository.DeleteOneById(createdHotelAttractionUrl.Entity.HotelAttractionId);

            // Assert
            Assert.AreEqual(_context.HotelAttraction.ToList().Count, 0);
        }

        [TestMethod]
        public void ShouldFindOneHotelAttractionById()
        {
            // Arrange
            HotelAttractionsRepositoryImp _repository = new HotelAttractionsRepositoryImp(_context);
            HotelAttraction newHotelAttraction = new HotelAttraction { Name = "HotelAttraction" };

            // Act
            var createdHotelAttraction = _context.HotelAttraction.Add(newHotelAttraction);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(
                _repository.FindOneById(
                createdHotelAttraction.Entity.HotelAttractionId).HotelAttractionId, 
                createdHotelAttraction.Entity.HotelAttractionId
                );
        }

        [TestMethod]
        public void ShouldCheckIfHotelAttractionExists()
        {
            // Arrange
            HotelAttractionsRepositoryImp _repository = new HotelAttractionsRepositoryImp(_context);
            HotelAttraction newHotelAttraction = new HotelAttraction { Name = "HotelAttraction" };

            // Act
            var createdHotelAttraction = _context.HotelAttraction.Add(newHotelAttraction);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(_repository.CheckIfExistsById(createdHotelAttraction.Entity.HotelAttractionId), true);
            Assert.AreEqual(_repository.CheckIfExistsById(2), false);
        }

        [TestMethod]
        public void ShouldUpdateHotelAttraction()
        {
            // Arrange
            HotelAttractionsRepositoryImp _repository = new HotelAttractionsRepositoryImp(_context);
            HotelAttraction newHotelAttraction = new HotelAttraction { Name = "HotelAttraction" };

            // Act
            var createdHotelAttraction = _context.HotelAttraction.Add(newHotelAttraction);
            _context.SaveChanges();

            var reservation = createdHotelAttraction.Entity;
            reservation.Name = "testingtesting";
            _repository.UpdateOne(reservation);

            // Assert
            Assert.AreNotEqual(_context.HotelAttraction.ToList().Where(i => i.HotelAttractionId == reservation.HotelAttractionId).First().Name, "testing");
        }
    }
}
