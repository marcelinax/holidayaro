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
    public class PaymentRepositoryImp : IPaymentRepository
    {
        private ApplicationDbContext _context;

        public PaymentRepositoryImp(ApplicationDbContext context)
        {
            _context = context;
        }

        public Payment AddNew(Payment payment)
        {
            _context.Payment.Add(payment);
            _context.SaveChanges();
            return payment;
        }

        public Payment DeleteOneById(int id)
        {
            var payment = _context.Payment.Find(id);
            _context.Payment.Remove(payment);
            _context.SaveChanges();
            return payment;
        }

        public Payment FindOneById(int id)
        {
            return _context.Payment.Find(id);
        }

        public IList<Payment> FindAll()
        {
            return _context.Payment.ToList();
        }

        public bool CheckIfExistsById(int id)
        {
            return _context.Payment.Any(e => e.PaymentId == id);
        }

        public Payment UpdateOne(Payment payment)
        {
            _context.Entry(payment).State = EntityState.Modified;
            _context.SaveChanges();
            return payment;
        }

        public dynamic GetManyByPageSizeAndOffset(int pageSize, int startIndex = -1)
        {
            var applicationDbContext = _context.Payment.Include(p => p.Reservation);
            dynamic results = new ExpandoObject();
            results.results = applicationDbContext.ToList().Skip(startIndex).Take(pageSize);
            results.amount = applicationDbContext.ToList().Count();
            if (startIndex == -1)
            {
                results.results = applicationDbContext.ToList();
            }
            return results;
        }
    }
}
