using Microsoft.AspNetCore.Mvc;

namespace StimulusChallenge.API.Controllers
{
    public class PledgeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}