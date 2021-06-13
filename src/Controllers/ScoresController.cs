using Bowling.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bowling
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        [HttpGet]
        public ActionResult<GameResult> GetScores()
        {
            return new GameResult { FrameProgressScores = new string[] { "12", "13", "14" }, GameCompleted = true };
        }

    }

}