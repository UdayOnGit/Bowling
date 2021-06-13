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

        public ResponseModel ThrowResult(RequestModel requestModel)
        {
            _logger.LogInformation($"{string.Join(",", requestModel.PinsDowned)}");

            var result = new ResponseModel
            {
                GameCompleted = true,
                FrameProgressScores = new string[]
                {
                    "10",
                    "20",
                    "30",
                    "40"
                }
            };
            return result;
        }
    }
}