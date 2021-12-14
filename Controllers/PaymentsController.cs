using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Holidayaro.Data;
using Holidayaro.Models;
using Holidayaro.Repositories;

namespace Holidayaro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    { 
        private readonly IRepository<Payment> _paymentRepository;

        public PaymentsController(IRepository<Payment> paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        // GET: api/Payments
        [HttpGet]
        public IList<Payment> GetPayment()
        {
            return _paymentRepository.FindAll();
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public Payment GetPayment(int id)
        {
            return _paymentRepository.Find(id);
        }

        // PUT: api/Payments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutPayment(int id, Payment payment)
        {
            _paymentRepository.Update(payment);

            return NoContent();
        }

        // POST: api/Payments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Payment> PostPayment(Payment payment)
        {
            Payment p = _paymentRepository.Add(payment);

            return CreatedAtAction("GetPayment", new { id = p.PaymentId }, p);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public IActionResult DeletePayment(int id)
        {
            _paymentRepository.Delete(id);
            return NoContent();
        }

        private bool PaymentExists(int id)
        {
            return _paymentRepository.Exists(id);
        }
    }
}
