using Holidayaro.Data;
using Holidayaro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holidayaro.Repositories
{
    public class PaymentRepositoryImp : IRepository<Payment>
    {
        private ApplicationDbContext _context;

        public PaymentRepositoryImp(ApplicationDbContext context)
        {
            _context = context;
        }

        public Payment Add(Payment payment)
        {
            _context.Payment.Add(payment);
            _context.SaveChanges();
            return payment;
        }

        public Payment Delete(int id)
        {
            var payment = _context.Payment.Find(id);
            _context.Payment.Remove(payment);
            _context.SaveChanges();
            return payment;
        }

        public Payment Find(int id)
        {
            return _context.Payment.Find(id);
        }

        public IList<Payment> FindAll()
        {
            return _context.Payment.ToList();
        }

        public bool Exists(int id)
        {
            return _context.Payment.Any(e => e.PaymentId == id);
        }

        public Payment Update(Payment payment)
        {
            _context.Entry(payment).State = EntityState.Modified;
            _context.SaveChanges();
            return payment;
        }
    }
}
