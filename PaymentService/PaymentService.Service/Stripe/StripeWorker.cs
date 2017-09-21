using PaymentService.Service.Properties;
using Stripe;

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
