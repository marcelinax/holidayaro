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
    public class ReservationRepositoryTests
    {
        ApplicationDbContext _context;

        public ReservationRepositoryTests()
        {
            DbContextOptionsBuilder<Holidayaro.Data.ApplicationDbContext> dbOptions = new DbContextOptionsBuilder<Holidayaro.Data.ApplicationDbContext>()
                .UseInMemoryDatabase(
                    Guid.NewGuid().ToString()
                );

            _context = new ApplicationDbContext(dbOptions.Options);
        }


        [TestMethod]
        public void ShouldCreateReservation()
        {
            // Arrange
            ReservationRepositoryImp _repository = new ReservationRepositoryImp(_context);
            Reservation newReservation = new Reservation { UserToken = "test", Date = new DateTime(), DateOfBirth = new DateTime(), Email = "test", Name = "test", Phone = "test", Surname = "test", HotelId = 1 };

            // Act
            _repository.AddNew(newReservation);

            // Assert
            Assert.AreEqual(_context.Reservation.ToList().Count, 1);
        }

        [TestMethod]
        public void ShouldReturnAllReservation()
        {
            // Arrange
            ReservationRepositoryImp _repository = new ReservationRepositoryImp(_context);
            Reservation newReservation1 = new Reservation { UserToken = "test", Date = new DateTime(), DateOfBirth = new DateTime(), Email = "test", Name = "test", Phone = "test", Surname = "test", HotelId = 1 };
            Reservation newReservation2 = new Reservation { UserToken = "test", Date = new DateTime(), DateOfBirth = new DateTime(), Email = "test", Name = "test", Phone = "test", Surname = "test", HotelId = 1 };
            Reservation newReservation3 = new Reservation { UserToken = "test", Date = new DateTime(), DateOfBirth = new DateTime(), Email = "test", Name = "test", Phone = "test", Surname = "test", HotelId = 1 };
            Reservation newReservation4 = new Reservation { UserToken = "test", Date = new DateTime(), DateOfBirth = new DateTime(), Email = "test", Name = "test", Phone = "test", Surname = "test", HotelId = 1 };

            // Act
            _context.Reservation.Add(newReservation1);
            _context.Reservation.Add(newReservation2);
            _context.Reservation.Add(newReservation3);
            _context.Reservation.Add(newReservation4);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(_repository.FindAll().Count, 4);
        }

        [TestMethod]
        public void ShouldRemoveReservation()
        {
            // Arrange
            ReservationRepositoryImp _repository = new ReservationRepositoryImp(_context);
            Reservation newReservation = new Reservation { UserToken = "test", Date = new DateTime(), DateOfBirth = new DateTime(), Email = "test", Name = "test", Phone = "test", Surname = "test", HotelId = 1 };

            // Act
            var createdReservationUrl = _context.Reservation.Add(newReservation);
            _context.SaveChanges();

            _repository.DeleteOneById(createdReservationUrl.Entity.ReservationId);

            // Assert
            Assert.AreEqual(_context.Reservation.ToList().Count, 0);
        }

        [TestMethod]
        public void ShouldFindOneReservationById()
        {
            // Arrange
            ReservationRepositoryImp _repository = new ReservationRepositoryImp(_context);
            Reservation newReservation = new Reservation { UserToken = "test", Date = new DateTime(), DateOfBirth = new DateTime(), Email = "test", Name = "test", Phone = "test", Surname = "test" };

            // Act
            var createdReservation = _context.Reservation.Add(newReservation);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(
                _repository.FindOneById(
                createdReservation.Entity.ReservationId).ReservationId, 
                createdReservation.Entity.ReservationId
                );
        }

        [TestMethod]
        public void ShouldCheckIfReservationExists()
        {
            // Arrange
            ReservationRepositoryImp _repository = new ReservationRepositoryImp(_context);
            Reservation newReservation = new Reservation { UserToken = "test", Date = new DateTime(), DateOfBirth = new DateTime(), Email = "test", Name = "test", Phone = "test", Surname = "test", HotelId = 1 };

            // Act
            var createdReservation = _context.Reservation.Add(newReservation);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(_repository.CheckIfExistsById(createdReservation.Entity.ReservationId), true);
            Assert.AreEqual(_repository.CheckIfExistsById(2), false);
        }

        [TestMethod]
        public void ShouldUpdateReservation()
        {
            // Arrange
            ReservationRepositoryImp _repository = new ReservationRepositoryImp(_context);
            Reservation newReservation = new Reservation { UserToken = "test", Date = new DateTime(), DateOfBirth = new DateTime(), Email = "test", Name = "test", Phone = "test", Surname = "test", HotelId = 1 };

            // Act
            var createdReservation = _context.Reservation.Add(newReservation);
            _context.SaveChanges();

            var reservation = createdReservation.Entity;
            reservation.Name = "testingtesting";
            _repository.UpdateOne(reservation);

            // Assert
            Assert.AreNotEqual(_context.Reservation.ToList().Where(i => i.ReservationId == reservation.ReservationId).First().Name, "http://google.pl/super_projekt.png");
        }
    }
}
