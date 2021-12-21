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
        private readonly IPaymentRepository _paymentRepository;

        public PaymentsController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpGet]
        public IList<Payment> GetPayment()
        {
            return _paymentRepository.FindAll();
        }

        [HttpGet("{id}")]
        public Payment GetPayment(int id)
        {
            return _paymentRepository.FindOneById(id);
        }

        [HttpPut("{id}")]
        public Payment PutPayment(int id, Payment payment)
        {
            return _paymentRepository.UpdateOne(payment);
        }

        [HttpPost]
        public ActionResult<Payment> PostPayment(Payment payment)
        {
            Payment p = _paymentRepository.AddNew(payment);
            return CreatedAtAction("GetPayment", new { id = p.PaymentId }, p);
        }

        [HttpDelete("{id}")]
        public Payment DeletePayment(int id)
        {
            return _paymentRepository.DeleteOneById(id);
        }

        private bool PaymentExists(int id)
        {
            return _paymentRepository.CheckIfExistsById(id);
        }
    }
}
