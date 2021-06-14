using Bowling.Models;

namespace Bowling.Services
{
    public interface IBowlingService
    {
        ResponseModel GetGameResult(RequestModel requestModel);
    }
}