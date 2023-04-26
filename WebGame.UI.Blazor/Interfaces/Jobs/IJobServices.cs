using WebGame.UI.Blazor.Services;

namespace WebGame.UI.Blazor.Interfaces.Jobs
{
    public interface IJobServices
    {
        Task<TimeActionResponse> CheckJob();
        Task<BasicResponse> RewardJob();
        Task<BasicResponse> SetJobToPlayer(int duration);
    }
}
