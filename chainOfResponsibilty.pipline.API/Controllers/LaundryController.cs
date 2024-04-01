using chainOfResponsibilty.pipline.Domaine.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chainOfResponsibilty.pipline.API.Controllers
{
    [Route("api/laundry")]
    [ApiController]
    public class LaundryController : ControllerBase
    {

        [HttpPost("/subId")]
        public ActionResult Post([FromBody]Operation operation,int subId)
        {
            if (operation == null && subId > 0) {

                return BadRequest();
            }

            if(ModelState.IsValid)
            {
                return Ok();
            }

            return BadRequest();
            
        }
        
    }
}
