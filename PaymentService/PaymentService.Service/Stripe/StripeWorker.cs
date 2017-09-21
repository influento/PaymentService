using PaymentService.Service.Properties;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentService.Service.Stripe
{
    public abstract class StripeWorker
    {
        public StripeWorker()
        {
            StripeConfiguration.SetApiKey(Resources.SecretKey);
        }
    }
}
