using chainOfResponsibilty.pipline.API.Controllers;
using chainOfResponsibilty.pipline.Domaine.Entities;
using System.Text.Json;

namespace chainOfResponsibilty.pipline.API
{
    public class MachineMidlleware : IMiddleware
    {

        private readonly MachineController _machineController;
      

        public MachineMidlleware(MachineController machineController)
        {
         
            _machineController = machineController;
            
        }

        public async Task InvokeAsync(HttpContext context,RequestDelegate next)
        {
            //Operation? operation = context.Items["ClientRequest"] as Operation;
            //Operation? operation = await JsonSerializer.DeserializeAsync<Operation>(context.Request.Body);
            Operation? operation = context.Items["ClientRequestData"] as Operation;

            if (operation is null)
            {
                context.Response.StatusCode = 400;
            }
            else
            {
                _machineController.Post(operation);
                context.Response.StatusCode = 200;
                await next(context);

            }
                


           
            

        }



    }

    public static class RequestLaundryMachineMidllewareExtensions
    {
        public static IApplicationBuilder UseMachineRequest(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MachineMidlleware>();
        }
    }
}
