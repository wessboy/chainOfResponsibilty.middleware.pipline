using chainOfResponsibilty.pipline.Domaine.Entities;
using chainOfResponsibilty.pipline.Domaine.Services;
using System.Text.Json;

namespace chainOfResponsibilty.pipline.API
{
    public class RequestLaundryMidlleware 
    {
        private readonly RequestDelegate _next;
        private readonly IPaymentManager _paymentManager;
        private readonly IMachineManager _machineManager;


        public RequestLaundryMidlleware(RequestDelegate next , IMachineManager machineManager,IPaymentManager paymentManager)
        {
            _next = next;
            _machineManager = machineManager;
            _paymentManager = paymentManager;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            bool paymentResult = false;
            bool activationResult = false;
            int subId = 0;
            string response = "failed to process customer rerquest !!";

            StreamReader reader = new StreamReader(context.Request.Body,leaveOpen:true);
            var text = await reader.ReadToEndAsync();
 
            Operation laundryRequest = JsonSerializer.Deserialize<Operation>(text);
         


            string valueFromPath = context.Request.Query["subId"].ToString();
            
            if(valueFromPath is not null)
            {
                subId = int.Parse(valueFromPath);
            }
            

            paymentResult = _paymentManager.CalculateFee(laundryRequest.Fee,subId);
              

            if (paymentResult)
            {
                activationResult = _machineManager.Activate(laundryRequest.Machine.Name);

                if (activationResult)
                {
                    
                     response = $"{laundryRequest.Type} operation with fee {laundryRequest.Fee} processed suscessfuly";
                    
                 
                }

                    
            }



            response = JsonSerializer.Serialize(response);
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(response);    
            await _next(context);

            

        }



    }

    public static class RequestLaundryPaymentMidllewareExtensions
    {
        public static IApplicationBuilder UseLaundryRequest(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLaundryMidlleware>();
        }
    }
}
