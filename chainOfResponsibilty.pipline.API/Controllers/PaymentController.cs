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
                return BadRequest("provide a valid entery !!");
          
            
          bool result = _paymentManager.CalculateFee(operation.Fee, subId);

            if (result)
            {
                return Ok($"payment for {operation.Fee}$ fee processed successfully");

            }
                
            

            return BadRequest("payment failed to be processed");

            
        }
    }
}
