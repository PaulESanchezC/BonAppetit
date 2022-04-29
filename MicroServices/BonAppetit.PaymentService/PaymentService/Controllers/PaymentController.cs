using Microsoft.AspNetCore.Mvc;
using Models.PaymentModels;
using Models.StripeSessionModels;
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
        public async Task<IActionResult> CreatePaymentSession([FromBody] StripeSessionCreate paymentInformation,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = await _paymentServices.CreateStripePaymentSessionAsync(paymentInformation, cancellationToken);
            return StatusCode(request.StatusCode,request);
        }

        [HttpPost("ConfirmPayment")]
        public async Task<IActionResult> ConfirmPayment([FromBody]PaymentSuccess paymentSuccess, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = await _paymentServices.ConfirmPaymentIsSuccessful(paymentSuccess.PaymentCreate, paymentSuccess.PaymentMessage, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }
    }
}
