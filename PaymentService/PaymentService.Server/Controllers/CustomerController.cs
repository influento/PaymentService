using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaymentService.Service.Abstract;
using PaymentService.Service.ViewModels.Request.CustomerVM;
using PaymentService.Service.ViewModels.Response.CustomerVM;
using System;
using System.Threading.Tasks;

namespace PaymentService.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerWorker _customerWorker;
        private readonly ILogger _logger;

        public CustomerController(ICustomerWorker customerWorker, ILogger<CustomerController> logger)
        {
            _customerWorker = customerWorker;
            _logger = logger;
        }

        /// <summary>
        /// Creates customer in payment service
        /// </summary>
        /// <param name="request"></param>
        /// <response code="200">Customer was created successfully</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="500">Ooops! Some problems occured during request execution</response>
        [HttpPost("create-customer")]
        [ProducesResponseType(typeof(CreateCustomerResponseVM), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequestVM request)
        {
            try
            {
                if (request != null && request.IsValid())
                {
                    var response = await _customerWorker.Create(request);
                    return Ok(response);
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, e.Message, request);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Updates customer information in payment service
        /// </summary>
        /// <param name="request"></param>
        /// <response code="200">Customer was updated successfully</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="500">Ooops! Some problems occured during request execution</response>
        [HttpPost("update-customer")]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerRequestVM request)
        {
            try
            {
                if (request != null && request.IsValid())
                {
                    await _customerWorker.Update(request);
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, e.Message, request);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}