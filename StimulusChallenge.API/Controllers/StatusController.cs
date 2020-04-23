using Microsoft.AspNetCore.Mvc;

namespace StimulusChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        public StatusController() { }

        [HttpGet]
        public int GetStatus()
        {
            return 200;
        }
    }
}
