using WebGame.UI.Blazor.Services;
using WebGame.UI.Blazor.ViewModels.Missions;

namespace WebGame.UI.Blazor.Interfaces.Missions
{
    public interface IMissionServices
    {
        Task<TimeActionResponse> CheckMission();
        Task<ICollection<MissionBlazorVM>> GetMissions();
        Task<BasicResponse> RewardMission();
        Task<BasicResponse> SetMissionToPlayer(int id);
    }
}
