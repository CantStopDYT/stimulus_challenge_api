using System;
using System.Net;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using StimulusChallenge.API.Models;
using StimulusChallenge.API.Services;

namespace StimulusChallenge.API.Controllers
{
    public class PledgeController : Controller
    {
        private static IConfiguration _config;
        private static IDatabaseService _db;
        
        public PledgeController(IConfiguration config, IDatabaseService db)
        {
            _config = config;
            _db = db;
        }

        [HttpPost]
        public IActionResult SavePledge([FromBody]Pledge pledge)
        {
            var result = 0;

            if (string.IsNullOrEmpty(pledge.ZipCode)) throw new ArgumentException("ZIP Code is required.");
            if (pledge.NonProfit > 0 && pledge.SmallBiz > 0) throw new ArgumentException("At least one of Non-profit Donation or Small Business Commitment is required.");
            
            //pledge.Name = 

            try
            {
                result = _db.SavePledge(_config, pledge);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Database save failed.", ex);
            }

            pledge.ID = result;

            return new CreatedResult("", pledge);
        }
    }
}