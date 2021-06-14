using Xunit;
using Bowling.Services;
using Moq;
using Microsoft.Extensions.Logging;
using Bowling.Models;
using FluentAssertions;

namespace BowlingTests.Services
{
    public class BowlingServiceTests
    {
        [Fact]
        public void Should_Return_Frame_Progress_And_Game_Result()
        {
            // Arrange
            var logger = new Mock<ILogger<BowlingService>>();
            var service = new BowlingService(logger.Object);
            var requestModel = new RequestModel
            {
                PinsDowned = new int[] { 2, 7, 6, 2, 6, 3, 7, 2, 9, 0, 0, 0, 6, 2, 8, 1, 7, 1, 6, 1 }
            };
            var responseModel = new ResponseModel
            {
                FrameProgressScores = new string[] { "9", "17", "26", "35", "44", "44", "52", "61", "69", "76" },
                GameCompleted = true
            };

            // Act
            var result = service.ThrowResult(requestModel);

            // Assert
            result.Should().BeEquivalentTo<ResponseModel>(responseModel);
        }

    }
}