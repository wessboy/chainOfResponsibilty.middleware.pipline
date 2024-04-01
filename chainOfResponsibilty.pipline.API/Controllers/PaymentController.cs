using chainOfResponsibilty.pipline.Domaine.Entities;
using chainOfResponsibilty.pipline.Domaine.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chainOfResponsibilty.pipline.API.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentManager _paymentManager;
        public PaymentController(IPaymentManager paymentManager)
        {
            _paymentManager = paymentManager;
        }

        [HttpPost("/processPayment")]
        public ActionResult Post(Operation operation,int subId)
        {
            if (operation == null && subId > 0)
                return BadRequest();
            if (ModelState.IsValid)
            {
                _paymentManager.CalculateFee(operation.Fee, subId);
                return Ok();
            }

            return BadRequest();

            
        }
    }
}
