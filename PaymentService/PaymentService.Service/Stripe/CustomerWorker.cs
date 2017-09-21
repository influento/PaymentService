using PaymentService.Service.Abstract;
using PaymentService.Service.Entities;
using PaymentService.Service.ViewModels.Response;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Service.Stripe
{
    public class CustomerWorker : StripeWorker, ICustomerWorker
    {
        public async Task<CreateCustomerResponseVM> Create(Customer customer)
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

        public async Task Update(Customer customer)
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
            await customerService.UpdateAsync(customer.Id, customerOptions);
        }
    }
}
