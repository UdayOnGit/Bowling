using System.Collections.Generic;
using System.Linq;
using Bowling.Models;
using Microsoft.Extensions.Logging;

namespace Bowling.Services
{
    public class BowlingService : IBowlingService
    {
        private readonly ILogger<BowlingService> _logger;
        private const int MaximumFrameCount = 10;
        private const int StrikeOrSparePoints = 10;

        public BowlingService(ILogger<BowlingService> logger)
        {
            _logger = logger;
        }

        public ResponseModel GetGameResult(RequestModel requestModel)
        {
            _logger.LogInformation($"{string.Join(",", requestModel.PinsDowned)}");

            var pins = requestModel.PinsDowned.ToList();

            var frames = new List<Frame>();
            int rollNumber = 0;
            var pinsDowned = requestModel.PinsDowned;

            for (int frameNumber = 0; frameNumber < MaximumFrameCount; frameNumber++)
            {
                if (rollNumber >= pinsDowned.Length)
                {
                    break;
                }

                int previousFrameScore = frames.LastOrDefault()?.Score ?? 0;
                var frame = new Frame();
                frames.Add(frame);
                if (IsItAStrike(pinsDowned, rollNumber))
                {
                    frame.Score = previousFrameScore + StrikeOrSparePoints + GetStrikeBonus(pinsDowned, rollNumber);
                    rollNumber++;
                }
                else if (IsItASpare(pinsDowned, rollNumber))
                {
                    frame.Score = previousFrameScore + StrikeOrSparePoints + GetSpareBonus(pinsDowned, rollNumber);
                    rollNumber += 2;
                }
                else
                {
                    frame.Score = previousFrameScore + pinsDowned[rollNumber] + pinsDowned[rollNumber + 1];
                    rollNumber += 2;
                }
            }

            return GetResponseModel(frames);
        }

        private ResponseModel GetResponseModel(List<Frame> frames)
        {
            var frameScores = frames.Select(x => x.Score.ToString());

            return new ResponseModel
            {
                GameCompleted = frames.Count == MaximumFrameCount,
                FrameProgressScores = frameScores.ToArray()
            };
        }

        private bool IsItAStrike(int[] pinsDowned, int rollNumer) => pinsDowned[rollNumer] == 10;

        private int GetStrikeBonus(int[] pinsDowned, int rollNumber)
        {
            var strikeScore = 0;
            if ((rollNumber + 1) < pinsDowned.Length)
            {
                strikeScore += pinsDowned[rollNumber + 1];
            }
            if ((rollNumber + 2) < pinsDowned.Length)
            {
                strikeScore += pinsDowned[rollNumber + 2];
            }
            return strikeScore;
        }

        private bool IsItASpare(int[] pinsDowned, int rollNumber) => pinsDowned[rollNumber] + pinsDowned[rollNumber + 1] == 10;

        private int GetSpareBonus(int[] pinsDowned, int rollNumber)
        {
            if ((rollNumber + 2) < pinsDowned.Length)
                return pinsDowned[rollNumber + 2];
            else
                return 0;
        }

        public class Frame
        {
            public int Score { get; set; }
        }
    }

}