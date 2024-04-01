using chainOfResponsibilty.pipline.API.Filters;
using chainOfResponsibilty.pipline.Domaine.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace chainOfResponsibilty.pipline.API.Controllers
{
    [Route("api/laundry")]
    [ApiController]
    public class LaundryController : ControllerBase
    {

        [HttpPost("/subId")]
        [ServiceFilter(typeof(LaundryFilter))]
        public ActionResult Post([FromBody]Operation operation,int subId)
        {
            if (operation == null && subId > 0) {

                return BadRequest();
            }

            if(ModelState.IsValid)
            {
                HttpContext.Items["ClientRequest"] = operation;
               
                return Ok();
            }

            return BadRequest();
            
        }
        
    }
}
