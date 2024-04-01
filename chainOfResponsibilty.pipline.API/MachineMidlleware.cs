using chainOfResponsibilty.pipline.API.Controllers;
using chainOfResponsibilty.pipline.Domaine.Entities;
using chainOfResponsibilty.pipline.Domaine.Services;
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
            Operation? operation = context.Items["ClientRequest"] as Operation;
            

            if (operation is null)
            {
                context.Response.StatusCode = 400;
            }
            else
            {
                _machineController.Post(operation);
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
