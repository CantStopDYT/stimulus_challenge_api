using Microsoft.Extensions.Configuration;

using StimulusChallenge.API.Models;

namespace StimulusChallenge.API.Services
{
    public interface IDatabaseService
    {
        Stats GetStats(IConfiguration config);

        int SavePledge(IConfiguration config, Pledge pledge);
    }
}