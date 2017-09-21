using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentService.Service.Entities
{
    public class Customer
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public Card Card { get; set; }
    }
}
