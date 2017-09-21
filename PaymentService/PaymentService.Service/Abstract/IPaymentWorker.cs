using PaymentService.Service.Entities;
using PaymentService.Service.ViewModels.Request.PaymentVM;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentService.Service.Abstract
{
    public interface IPaymentWorker
    {
        /// <summary>
        /// Makes regular payment in payment service (use for authorized customer)
        /// </summary>
        /// <param name="payment"></param>
        Task MakeRegularPayment(RegularPaymentsRequestVM payment);

        /// <summary>
        /// Makes one time payment in payment service (use for unregistered/unauthorized customer)
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        Task MakeOneTimePayment(OneTimePaymentRequestVM payment);

        /// <summary>
        /// Retrieves all payments of customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>
        /// List of payments of customer with id = customerId
        /// </returns>
        Task<IEnumerable<Payment>> GetCustomerPayments(string customerId);
    }
}
