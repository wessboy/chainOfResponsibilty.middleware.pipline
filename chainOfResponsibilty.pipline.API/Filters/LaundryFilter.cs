using chainOfResponsibilty.pipline.Domaine.Entities;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace chainOfResponsibilty.pipline.API.Filters
{
    public class LaundryFilter : IActionFilter
    {
        public LaundryFilter()
        {
            
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
          
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Operation? operation = JsonSerializer.Deserialize<Operation>(context.HttpContext.Request.Body);

            if (operation != null)
            {
                context.HttpContext.Items["ClientRequest"] = operation;
            }
        }
    }
}
