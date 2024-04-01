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
            context.Items.TryGetValue("ClientRequest", out var operationValue);
            Operation? operation = JsonSerializer.Deserialize<Operation>(operationValue.ToString());

            var subIdQuery = context.Request.Query["subId"];

            if (operationValue is null || String.IsNullOrEmpty(subIdQuery))
            {
                context.Response.StatusCode = 400;
            }
            else
            {
                int subId = int.Parse(subIdQuery);
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
