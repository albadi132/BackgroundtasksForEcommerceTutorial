using BackgroundtasksForEcommerceTutorial.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundtasksForEcommerceTutorial.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BackgroundController : ControllerBase
    {

        private readonly PeriodicHostedService _service;

        public BackgroundController(PeriodicHostedService service)
        {
            _service = service;

        }


        [HttpGet]
        public PeriodicHostedServiceState GetSendDiscountCodeTaskStatus()
        {
            
            return new PeriodicHostedServiceState(_service.IsEnabled);

        }

        [HttpPost]
        public async Task<ActionResult<bool>> PatchSendDiscountCodeTaskStatus([FromBody] PeriodicHostedServiceState state)
        {
            _service.IsEnabled = state.IsEnabled;
            await Task.CompletedTask; // Placeholder for async operations
            return NoContent();

        }
    }
}
