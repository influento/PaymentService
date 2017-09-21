using PaymentService.Service.Entities;
using PaymentService.Service.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;
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
        Task<CreateCustomerResponseVM> Create(Customer customer);

        /// <summary>
        /// Updates customer in payment service
        /// </summary>
        /// <param name="customer"></param>
        Task Update(Customer customer);

        /// <summary>
        /// Deletes customer in payment Service
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task Delete(string customerId);
    }
}
