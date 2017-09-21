using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Service.Entities;
using PaymentService.Service.Abstract;
using PaymentService.Service.ViewModels.Request;

namespace PaymentService.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/payment")]
    public class PaymentController : Controller
    {
        private readonly IPaymentWorker _paymentWorker;

        public PaymentController(IPaymentWorker paymentWorker)
        {
            _paymentWorker = paymentWorker;
        }

        /// <summary>
        /// Makes payment by usual (authorized) customer to payment service
        /// </summary>
        /// <param name="request"></param>
        /// <response code="200">Successfull payment</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="500">Ooops! Some problems occured during request execution</response>
        [HttpPost("make-regular-payment")]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> MakeRegularPayment([FromBody] Payment request)
        {
            try
            {
                if (request != null)
                {
                    await _paymentWorker.MakeRegularPayment(request);
                    return Ok();
                }
                return BadRequest();
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Makes one time payment when customer is not registered/authorized
        /// </summary>
        /// <param name="request"></param>
        /// <response code="200">Successfull payment</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="500">Ooops! Some problems occured during request execution</response>
        [HttpPost("make-one-time-payment")]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public IActionResult MakeOneTimePayment([FromBody] OneTimePaymentRequestVM request)
        {
            try
            {
                if (request != null)
                {
                    _paymentWorker.MakeOneTimePayment(request);
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}