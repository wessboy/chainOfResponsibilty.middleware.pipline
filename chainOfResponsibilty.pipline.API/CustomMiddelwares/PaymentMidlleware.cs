using chainOfResponsibilty.pipline.API.Controllers;
using chainOfResponsibilty.pipline.Domaine.Entities;
using System.Text.Json;

namespace chainOfResponsibilty.pipline.API.CustomMiddelwares
{
    public class PaymentMidlleware : IMiddleware
    {

        private readonly PaymentController _paymentController;




        public PaymentMidlleware(PaymentController paymentController)
        {

            _paymentController = paymentController;


        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //context.Items.TryGetValue("ClientRequest", out var operationValue);

            //Operation? operation = JsonSerializer.Deserialize<Operation>(operationValue.ToString());

            Operation? operation = await JsonSerializer.DeserializeAsync<Operation>(context.Request.Body);

            Operation? operationContext = context.Items["ClientRequest"] as Operation;

            var subIdQuery = context.Request.Query["subId"];

            if (operation is null || string.IsNullOrEmpty(subIdQuery))
            {
                context.Response.StatusCode = 400;
            }
            else
            {
                int subId = int.Parse(subIdQuery);
                _paymentController.Post(operation, subId);
                context.Items["ClientRequestData"] = operation;
                await next(context);

                await context.Response.WriteAsync("everything is good");

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
