using PaymentService.Service.ViewModels.Request.CustomerVM;
using PaymentService.Service.ViewModels.Response.CustomerVM;
using System.Threading.Tasks;

namespace PaymentService.Service.Abstract
{
    public interface ICustomerWorker
    {
        /// <summary>
        /// Creates customer in payment service
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>
        /// View model which contains customer id in payment service
        /// </returns>
        Task<CreateCustomerResponseVM> Create(CreateCustomerRequestVM customer);

        /// <summary>
        /// Updates customer in payment service
        /// </summary>
        /// <param name="customer"></param>
        Task Update(UpdateCustomerRequestVM customer);

        /// <summary>
        /// Deletes customer in payment Service
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task Delete(string customerId);
    }
}