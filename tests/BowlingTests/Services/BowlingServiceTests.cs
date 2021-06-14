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
        private Mock<ILogger<BowlingService>> _logger;
        private BowlingService _service;

        private void Setup()
        {
            _logger = new Mock<ILogger<BowlingService>>();
            _service = new BowlingService(_logger.Object);
        }

        [Fact]
        public void Test_All_Strikes()
        {
            // Arrange
            Setup();
            var requestModel = new RequestModel
            {
                PinsDowned = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }
            };
            var responseModel = new ResponseModel
            {
                FrameProgressScores = new string[] { "30", "60", "90", "120", "150", "180", "210", "240", "270", "300" },
                GameCompleted = true
            };

            // Act
            var result = _service.GetGameResult(requestModel);

            // Assert
            result.Should().BeEquivalentTo<ResponseModel>(responseModel);
        }

        [Fact]
        public void Test_All_Spares()
        {
            // Arrange
            Setup();
            var requestModel = new RequestModel
            {
                PinsDowned = new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }
            };
            var responseModel = new ResponseModel
            {
                FrameProgressScores = new string[] { "15", "30", "45", "60", "75", "90", "105", "120", "135", "150" },
                GameCompleted = true
            };

            // Act
            var result = _service.GetGameResult(requestModel);

            // Assert
            result.Should().BeEquivalentTo<ResponseModel>(responseModel);
        }

        [Fact]
        public void Test_All_Gutter()
        {
            // Arrange
            Setup();
            var requestModel = new RequestModel
            {
                PinsDowned = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };
            var responseModel = new ResponseModel
            {
                FrameProgressScores = new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                GameCompleted = true
            };

            // Act
            var result = _service.GetGameResult(requestModel);

            // Assert
            result.Should().BeEquivalentTo<ResponseModel>(responseModel);
        }

        [Fact]
        public void Test_All_With_1_Pin()
        {
            // Arrange
            Setup();
            var requestModel = new RequestModel
            {
                PinsDowned = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            };
            var responseModel = new ResponseModel
            {
                FrameProgressScores = new string[] { "2", "4", "6", "8", "10", "12", "14", "16", "18", "20" },
                GameCompleted = true
            };

            // Act
            var result = _service.GetGameResult(requestModel);

            // Assert
            result.Should().BeEquivalentTo<ResponseModel>(responseModel);
        }

        [Fact]
        public void Should_Return_Correct_Frame_Progress_And_Game_Result_For_Random_Rolls()
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
            var result = service.GetGameResult(requestModel);

            // Assert
            result.Should().BeEquivalentTo<ResponseModel>(responseModel);
        }

        [Fact]
        public void Test_Random_Pins_Incomplete()
        {
            // Arrange
            Setup();
            var requestModel = new RequestModel
            {
                PinsDowned = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            };
            var responseModel = new ResponseModel
            {
                FrameProgressScores = new string[] { "2", "4", "6", "8", "10", "12", "14", "16" },
                GameCompleted = false
            };

            // Act
            var result = _service.GetGameResult(requestModel);

            // Assert
            result.Should().BeEquivalentTo<ResponseModel>(responseModel);
        }

    }
}