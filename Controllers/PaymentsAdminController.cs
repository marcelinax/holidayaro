using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Holidayaro.Data;
using Holidayaro.Models;
using Microsoft.AspNetCore.Authorization;
using System.Dynamic;
using Holidayaro.Repositories;

namespace Holidayaro.Controllers
{
    [Authorize]
    public class PaymentsAdminController : Controller
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IReservationsRepository _reservationsRepository;

        public PaymentsAdminController(IPaymentRepository paymentRepository, IReservationsRepository reservationsRepository)
        {
            _paymentRepository = paymentRepository;
            _reservationsRepository = reservationsRepository;
        }

        public IActionResult Index(int pageSize, int startIndex = -1)
        {
            ViewBag.Results = _paymentRepository.GetManyByPageSizeAndOffset(pageSize, startIndex);

            return View();
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = _paymentRepository.FindOneById((int)id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = _paymentRepository.FindOneById((int)id);
            if (payment == null)
            {
                return NotFound();
            }
            ViewData["ReservationId"] = new SelectList(_reservationsRepository.FindAll(), "ReservationId", "Email", payment.ReservationId);
            return View(payment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("PaymentId,ReservationId,CreditCardNumber,PaypalEmail,CreditCardHolderName,CreditCardExpirationMonth,CreditCardExpirationYear,CreditCardCvv,PaymentAmount")] Payment payment)
        {
            if (id != payment.PaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _paymentRepository.UpdateOne(payment);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.PaymentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReservationId"] = new SelectList(_reservationsRepository.FindAll(), "ReservationId", "Email", payment.ReservationId);
            return View(payment);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = _paymentRepository.FindOneById((int)id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _paymentRepository.DeleteOneById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(int id)
        {
            return _paymentRepository.CheckIfExistsById(id);
        }
    }
}
