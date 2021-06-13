using Bowling.Models;
using Bowling.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bowling
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly IBowlingService _bowlingService;

        public ScoresController(IBowlingService bowlingService)
        {
            _bowlingService = bowlingService;
        }

        [HttpPost]
        public ActionResult<ResponseModel> GetScores([FromBody] RequestModel requestModel)
        {
            return _bowlingService.ThrowResult(requestModel);
        }
    }
}