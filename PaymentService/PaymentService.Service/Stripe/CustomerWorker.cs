using PaymentService.Service.Abstract;
using PaymentService.Service.ViewModels.Request.CustomerVM;
using PaymentService.Service.ViewModels.Response.CustomerVM;
using Stripe;
using System.Threading.Tasks;

namespace PaymentService.Service.Stripe
{
    public class CustomerWorker : StripeWorker, ICustomerWorker
    {
        public async Task<CreateCustomerResponseVM> Create(CreateCustomerRequestVM customer)
        {
            var sourceCard = new SourceCard()
            {
                Number = customer.Card.Number,
                Cvc = customer.Card.CVC,
                ExpirationMonth = customer.Card.ExpirationMonth,
                ExpirationYear = customer.Card.ExpirationYear
            };

            var customerOptions = new StripeCustomerCreateOptions()
            {
                SourceCard = sourceCard,
                Description = customer.Name,
                Email = customer.Email
            };

            var customerService = new StripeCustomerService();
            var stripeCustomer = await customerService.CreateAsync(customerOptions);
            return new CreateCustomerResponseVM()
            {
                CustomerId = stripeCustomer.Id
            };
        }

        public async Task Delete(string customerId)
        {
            var customerService = new StripeCustomerService();
            await customerService.DeleteAsync(customerId);
        }

        public async Task Update(UpdateCustomerRequestVM customer)
        {
            var sourceCard = new SourceCard()
            {
                Number = customer.Card.Number,
                Cvc = customer.Card.CVC,
                ExpirationMonth = customer.Card.ExpirationMonth,
                ExpirationYear = customer.Card.ExpirationYear
            };

            var customerOptions = new StripeCustomerUpdateOptions()
            {
                SourceCard = sourceCard,
                Description = customer.Name,
                Email = customer.Email
            };

            var customerService = new StripeCustomerService();
            await customerService.UpdateAsync(customer.CustomerId, customerOptions);
        }
    }
}
