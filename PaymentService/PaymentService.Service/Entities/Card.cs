using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentService.Service.Entities
{
    public class Card
    {
        public string Number { get; set; }
        
        public string CVC { get; set; }

        public int ExpirationMonth { get; set; }

        public int ExpirationYear { get; set; }
    }
}
