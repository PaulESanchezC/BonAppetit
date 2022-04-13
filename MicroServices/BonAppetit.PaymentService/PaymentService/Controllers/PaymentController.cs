using Microsoft.AspNetCore.Mvc;
using Models.PaymentModels;
using Services.PaymentServices;

namespace PaymentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServices _paymentServices;
        public PaymentController(IPaymentServices paymentServices)
        {
            _paymentServices = paymentServices;
        }

        [HttpPost("CreatePaymentSession")]
        public async Task<IActionResult> CreatePaymentSession([FromBody] PaymentCreate paymentInformation,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = await _paymentServices.CreateStripePaymentSessionAsync(paymentInformation, cancellationToken);
            return StatusCode(request.StatusCode,request);
        }

        [HttpPost("ConfirmPayment")]
        public async Task<IActionResult> ConfirmPayment([FromBody] PaymentDto paymentToConfirm, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = await _paymentServices.ConfirmPaymentIsSuccessful(paymentToConfirm, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }
    }
}
