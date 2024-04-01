using chainOfResponsibilty.pipline.API.Controllers;
using chainOfResponsibilty.pipline.Domaine.Entities;
using chainOfResponsibilty.pipline.Domaine.Services;
using System.Text.Json;

namespace chainOfResponsibilty.pipline.API
{
    public class PaymentMidlleware : IMiddleware
    {

        private readonly PaymentController _paymentController;
      

        public PaymentMidlleware(PaymentController paymentController)
        {
         
            _paymentController = paymentController;
            

        }

        public async Task InvokeAsync(HttpContext context,RequestDelegate next)
        {
            Operation operation = (Operation)context.Items["ClientRequest"];
            int subId = (int)context.Items["subId"];

            if (operation is null && subId == 0)
            {
                context.Response.StatusCode = 400;
            }
            else
            {
                _paymentController.Post(operation, subId);
                await next(context);

            }
                


           
            

        }



    }

    public static class RequestLaundryPaymentMidllewareExtensions
    {
        public static IApplicationBuilder UsePaymentRequest(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PaymentMidlleware>();
        }
    }
}
