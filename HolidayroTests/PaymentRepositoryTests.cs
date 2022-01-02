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
    public class PaymentRepositoryTests
    {
        ApplicationDbContext _context;

        public PaymentRepositoryTests()
        {
            DbContextOptionsBuilder<Holidayaro.Data.ApplicationDbContext> dbOptions = new DbContextOptionsBuilder<Holidayaro.Data.ApplicationDbContext>()
                .UseInMemoryDatabase(
                    Guid.NewGuid().ToString()
                );

            _context = new ApplicationDbContext(dbOptions.Options);
        }


        [TestMethod]
        public void ShouldCreatePayment()
        {
            // Arrange
            PaymentRepositoryImp _repository = new PaymentRepositoryImp(_context);
            Payment newPayment = new Payment { PaypalEmail = "testing" };

            // Act
            _repository.AddNew(newPayment);

            // Assert
            Assert.AreEqual(_context.Payment.ToList().Count, 1);
        }

        [TestMethod]
        public void ShouldReturnAllPayment()
        {
            // Arrange
            PaymentRepositoryImp _repository = new PaymentRepositoryImp(_context);
            Payment newPayment1 = new Payment { PaypalEmail = "testing" };
            Payment newPayment2 = new Payment { PaypalEmail = "testing" };
            Payment newPayment3 = new Payment { PaypalEmail = "testing" };
            Payment newPayment4 = new Payment { PaypalEmail = "testing" };

            // Act
            _context.Payment.Add(newPayment1);
            _context.Payment.Add(newPayment2);
            _context.Payment.Add(newPayment3);
            _context.Payment.Add(newPayment4);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(_repository.FindAll().Count, 4);
        }

        [TestMethod]
        public void ShouldRemovePayment()
        {
            // Arrange
            PaymentRepositoryImp _repository = new PaymentRepositoryImp(_context);
            Payment newPayment = new Payment { PaypalEmail = "testing" };

            // Act
            var createdPaymentUrl = _context.Payment.Add(newPayment);
            _context.SaveChanges();

            _repository.DeleteOneById(createdPaymentUrl.Entity.PaymentId);

            // Assert
            Assert.AreEqual(_context.Payment.ToList().Count, 0);
        }

        [TestMethod]
        public void ShouldFindOnePaymentById()
        {
            // Arrange
            PaymentRepositoryImp _repository = new PaymentRepositoryImp(_context);
            Payment newPayment = new Payment { PaypalEmail = "testing" };

            // Act
            var createdPayment = _context.Payment.Add(newPayment);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(
                _repository.FindOneById(
                createdPayment.Entity.PaymentId).PaymentId, 
                createdPayment.Entity.PaymentId
                );
        }

        [TestMethod]
        public void ShouldCheckIfPaymentExists()
        {
            // Arrange
            PaymentRepositoryImp _repository = new PaymentRepositoryImp(_context);
            Payment newPayment = new Payment { PaypalEmail = "testing" };

            // Act
            var createdPayment = _context.Payment.Add(newPayment);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(_repository.CheckIfExistsById(createdPayment.Entity.PaymentId), true);
            Assert.AreEqual(_repository.CheckIfExistsById(2), false);
        }

        [TestMethod]
        public void ShouldUpdatePayment()
        {
            // Arrange
            PaymentRepositoryImp _repository = new PaymentRepositoryImp(_context);
            Payment newPayment = new Payment { PaypalEmail = "testing" };

            // Act
            var createdPayment = _context.Payment.Add(newPayment);
            _context.SaveChanges();

            var reservation = createdPayment.Entity;
            reservation.PaypalEmail = "testingtesting";
            _repository.UpdateOne(reservation);

            // Assert
            Assert.AreNotEqual(_context.Payment.ToList().Where(i => i.PaymentId == reservation.PaymentId).First().PaypalEmail, "testing");
        }
    }
}
