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
    public class HotelRepositoryTests
    {
        ApplicationDbContext _context;

        public HotelRepositoryTests()
        {
            DbContextOptionsBuilder<Holidayaro.Data.ApplicationDbContext> dbOptions = new DbContextOptionsBuilder<Holidayaro.Data.ApplicationDbContext>()
                .UseInMemoryDatabase(
                    Guid.NewGuid().ToString()
                );

            _context = new ApplicationDbContext(dbOptions.Options);
        }


        [TestMethod]
        public void ShouldCreateHotel()
        {
            // Arrange
            HotelsRepositoryImp _repository = new HotelsRepositoryImp(_context);
            Hotel newHotel = new Hotel { Name = "Hotel" };

            // Act
            _repository.AddNew(newHotel);

            // Assert
            Assert.AreEqual(_context.Hotel.ToList().Count, 1);
        }

        [TestMethod]
        public void ShouldReturnAllHotel()
        {
            // Arrange
            HotelsRepositoryImp _repository = new HotelsRepositoryImp(_context);
            Hotel newHotel1 = new Hotel { Name = "Hotel" };
            Hotel newHotel2 = new Hotel { Name = "Hotel" };
            Hotel newHotel3 = new Hotel { Name = "Hotel" };
            Hotel newHotel4 = new Hotel { Name = "Hotel" };

            // Act
            _context.Hotel.Add(newHotel1);
            _context.Hotel.Add(newHotel2);
            _context.Hotel.Add(newHotel3);
            _context.Hotel.Add(newHotel4);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(_repository.FindAll().Count, 4);
        }

        [TestMethod]
        public void ShouldRemoveHotel()
        {
            // Arrange
            HotelsRepositoryImp _repository = new HotelsRepositoryImp(_context);
            Hotel newHotel = new Hotel { Name = "Hotel" };

            // Act
            var createdHotelUrl = _context.Hotel.Add(newHotel);
            _context.SaveChanges();

            _repository.DeleteOneById(createdHotelUrl.Entity.HotelId);

            // Assert
            Assert.AreEqual(_context.Hotel.ToList().Count, 0);
        }

        [TestMethod]
        public void ShouldFindOneHotelById()
        {
            // Arrange
            HotelsRepositoryImp _repository = new HotelsRepositoryImp(_context);
            Hotel newHotel = new Hotel { Name = "Hotel" };

            // Act
            var createdHotel = _context.Hotel.Add(newHotel);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(
                _repository.FindOneById(
                createdHotel.Entity.HotelId).HotelId, 
                createdHotel.Entity.HotelId
                );
        }

        [TestMethod]
        public void ShouldCheckIfHotelExists()
        {
            // Arrange
            HotelsRepositoryImp _repository = new HotelsRepositoryImp(_context);
            Hotel newHotel = new Hotel { Name = "Hotel" };

            // Act
            var createdHotel = _context.Hotel.Add(newHotel);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(_repository.CheckIfExistsById(createdHotel.Entity.HotelId), true);
            Assert.AreEqual(_repository.CheckIfExistsById(2), false);
        }

        [TestMethod]
        public void ShouldUpdateHotel()
        {
            // Arrange
            HotelsRepositoryImp _repository = new HotelsRepositoryImp(_context);
            Hotel newHotel = new Hotel { Name = "Hotel" };

            // Act
            var createdHotel = _context.Hotel.Add(newHotel);
            _context.SaveChanges();

            var reservation = createdHotel.Entity;
            reservation.Name = "testingtesting";
            _repository.UpdateOne(reservation);

            // Assert
            Assert.AreNotEqual(_context.Hotel.ToList().Where(i => i.HotelId == reservation.HotelId).First().Name, "testing");
        }
    }
}
