using System.Web.Http;

using Microsoft.Extensions.Configuration;

using StimulusChallenge.API.Models;
using StimulusChallenge.API.Services;

namespace StimulusChallenge.API.Controllers
{
    public class StatsController : ApiController
    {
        private static IConfiguration _config;
        private static IDatabaseService _db;
        
        public StatsController(IConfiguration config, IDatabaseService db)
        {
            _config = config;
            _db = db;
        }

        [HttpGet]
        public Stats GetStats()
        {
            var result = _db.GetStats(_config);

            return result;
        }
    }
}