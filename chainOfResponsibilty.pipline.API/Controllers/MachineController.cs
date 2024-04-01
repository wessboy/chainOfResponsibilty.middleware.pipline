using chainOfResponsibilty.pipline.Domaine.Entities;
using chainOfResponsibilty.pipline.Domaine.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chainOfResponsibilty.pipline.API.Controllers
{
    [Route("api/machine")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly IMachineManager _machineManager;
        public MachineController(IMachineManager machineManager)
        {
            _machineManager = machineManager;
        }

        [HttpPost("/activate")]
        public ActionResult Post(Operation operation)
        {
            if (operation == null)
                return BadRequest();
            if(ModelState.IsValid)
            {
                _machineManager.Activate(operation.Machine.Name);
                return Ok();
            }

            return BadRequest();

        }
    }
}
