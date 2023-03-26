using WebGame.UI.Blazor.Services;
using WebGame.UI.Blazor.ViewModels.Missions;

namespace WebGame.UI.Blazor.Interfaces.Missions
{
    public interface IMissionServices
    {
        Task<ICollection<MissionBlazorVM>> GetMissions();
        Task RewardPlayer(GetPlayerAllInfoViewModel player);
        Task<GetPlayerAllInfoViewModel> SetMissionToPlayer(int id, DateTime endTime);
    }
}
