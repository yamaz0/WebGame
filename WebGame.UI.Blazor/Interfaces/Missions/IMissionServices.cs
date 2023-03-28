using WebGame.UI.Blazor.Services;
using WebGame.UI.Blazor.ViewModels.Missions;

namespace WebGame.UI.Blazor.Interfaces.Missions
{
    public interface IMissionServices
    {
        Task<CheckMissionCommandResponse> CheckMission();
        Task<ICollection<MissionBlazorVM>> GetMissions();
        Task<StartMissionCommandResponse> SetMissionToPlayer(int id);
    }
}
