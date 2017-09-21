using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentService.Service.ViewModels.Request.Payment
{
    public class OneTimePaymentRequestVM
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string CardNumber { get; set; }

        public string CVC { get; set; }

        public int ExpirationMonth { get; set; }

        public int ExpirationYear { get; set; }

        public string Currency { get; set; }

        public int Amount { get; set; }
    }
}
