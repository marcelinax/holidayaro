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
    public class HotelDescriptionRepositoryTests
    {
        ApplicationDbContext _context;

        public HotelDescriptionRepositoryTests()
        {
            DbContextOptionsBuilder<Holidayaro.Data.ApplicationDbContext> dbOptions = new DbContextOptionsBuilder<Holidayaro.Data.ApplicationDbContext>()
                .UseInMemoryDatabase(
                    Guid.NewGuid().ToString()
                );

            _context = new ApplicationDbContext(dbOptions.Options);
        }


        [TestMethod]
        public void ShouldCreateHotelDescription()
        {
            // Arrange
            HotelDescriptionsRepositoryImp _repository = new HotelDescriptionsRepositoryImp(_context);
            HotelDescription newHotelDescription = new HotelDescription { Name = "HotelDescription" };

            // Act
            _repository.AddNew(newHotelDescription);

            // Assert
            Assert.AreEqual(_context.HotelDescription.ToList().Count, 1);
        }

        [TestMethod]
        public void ShouldReturnAllHotelDescription()
        {
            // Arrange
            HotelDescriptionsRepositoryImp _repository = new HotelDescriptionsRepositoryImp(_context);
            HotelDescription newHotelDescription1 = new HotelDescription { Name = "HotelDescription" };
            HotelDescription newHotelDescription2 = new HotelDescription { Name = "HotelDescription" };
            HotelDescription newHotelDescription3 = new HotelDescription { Name = "HotelDescription" };
            HotelDescription newHotelDescription4 = new HotelDescription { Name = "HotelDescription" };

            // Act
            _context.HotelDescription.Add(newHotelDescription1);
            _context.HotelDescription.Add(newHotelDescription2);
            _context.HotelDescription.Add(newHotelDescription3);
            _context.HotelDescription.Add(newHotelDescription4);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(_repository.FindAll().Count, 4);
        }

        [TestMethod]
        public void ShouldRemoveHotelDescription()
        {
            // Arrange
            HotelDescriptionsRepositoryImp _repository = new HotelDescriptionsRepositoryImp(_context);
            HotelDescription newHotelDescription = new HotelDescription { Name = "HotelDescription" };

            // Act
            var createdHotelDescriptionUrl = _context.HotelDescription.Add(newHotelDescription);
            _context.SaveChanges();

            _repository.DeleteOneById(createdHotelDescriptionUrl.Entity.HotelDescriptionId);

            // Assert
            Assert.AreEqual(_context.HotelDescription.ToList().Count, 0);
        }

        [TestMethod]
        public void ShouldFindOneHotelDescriptionById()
        {
            // Arrange
            HotelDescriptionsRepositoryImp _repository = new HotelDescriptionsRepositoryImp(_context);
            HotelDescription newHotelDescription = new HotelDescription { Name = "HotelDescription" };

            // Act
            var createdHotelDescription = _context.HotelDescription.Add(newHotelDescription);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(
                _repository.FindOneById(
                createdHotelDescription.Entity.HotelDescriptionId).HotelDescriptionId, 
                createdHotelDescription.Entity.HotelDescriptionId
                );
        }

        [TestMethod]
        public void ShouldCheckIfHotelDescriptionExists()
        {
            // Arrange
            HotelDescriptionsRepositoryImp _repository = new HotelDescriptionsRepositoryImp(_context);
            HotelDescription newHotelDescription = new HotelDescription { Name = "HotelDescription" };

            // Act
            var createdHotelDescription = _context.HotelDescription.Add(newHotelDescription);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(_repository.CheckIfExistsById(createdHotelDescription.Entity.HotelDescriptionId), true);
            Assert.AreEqual(_repository.CheckIfExistsById(2), false);
        }

        [TestMethod]
        public void ShouldUpdateHotelDescription()
        {
            // Arrange
            HotelDescriptionsRepositoryImp _repository = new HotelDescriptionsRepositoryImp(_context);
            HotelDescription newHotelDescription = new HotelDescription { Name = "HotelDescription" };

            // Act
            var createdHotelDescription = _context.HotelDescription.Add(newHotelDescription);
            _context.SaveChanges();

            var reservation = createdHotelDescription.Entity;
            reservation.Name = "testingtesting";
            _repository.UpdateOne(reservation);

            // Assert
            Assert.AreNotEqual(_context.HotelDescription.ToList().Where(i => i.HotelDescriptionId == reservation.HotelDescriptionId).First().Name, "testing");
        }
    }
}
