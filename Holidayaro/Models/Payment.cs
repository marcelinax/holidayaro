using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Holidayaro.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int ReservationId { get; set; }
        [ForeignKey("ReservationId")]
        public Reservation Reservation { get; set; }
        public string CreditCardNumber { get; set; }
        public string PaypalEmail { get; set; }
        public string CreditCardHolderName { get; set; }
        public string CreditCardExpirationMonth { get; set; }
        public string CreditCardExpirationYear { get; set; }
        public string CreditCardCvv { get; set; }
        public int PaymentAmount { get; set; }
    }
}
