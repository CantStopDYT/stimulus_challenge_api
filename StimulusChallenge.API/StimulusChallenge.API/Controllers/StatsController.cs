using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using StimulusChallenge.API.Services;

namespace StimulusChallenge.API.Controllers
{
    public class StatsController : Controller
    {
        private static IConfiguration _config;
        private static IDatabaseService _db;
        
        public StatsController(IConfiguration config, IDatabaseService db)
        {
            _config = config;
            _db = db;
        }

        [HttpGet]
        public JsonResult GetStats()
        {
            var result = _db.GetStats(_config);

            return new JsonResult(result);
        }
    }
}