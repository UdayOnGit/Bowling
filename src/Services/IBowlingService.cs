using Bowling.Models;

namespace Bowling.Services
{
    public interface IBowlingService
    {
        ResponseModel ThrowResult(RequestModel requestModel);
    }
}