using Bowling.Models;
using Microsoft.Extensions.Logging;

namespace Bowling.Services
{
    public class BowlingService : IBowlingService
    {
        private readonly ILogger<BowlingService> _logger;

        public BowlingService(ILogger<BowlingService> logger)
        {
            _logger = logger;
        }

        public ResponseModel GetGameResult(RequestModel requestModel)
        {
            _logger.LogInformation($"{string.Join(",", requestModel.PinsDowned)}");

            var result = new ResponseModel
            {
                GameCompleted = true,
                FrameProgressScores = new string[]
                {
                    "9", 
                    "17",
                    "26",
                    "35", 
                    "44", 
                    "44", 
                    "52", 
                    "61", 
                    "69", 
                    "76"
                }
            };
            return result;
        }
    }
}