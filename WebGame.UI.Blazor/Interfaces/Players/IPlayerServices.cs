using WebGame.UI.Blazor.Services;
using WebGame.UI.Blazor.ViewModels.Players;

namespace WebGame.UI.Blazor.Interfaces.Players
{
    public interface IPlayerServices
    {
        Task AddStat(Statistic statistic);
        Task<GetPlayerAllInfoViewModel> GetPlayer();
        Task<PlayerBlazorVM> GetPlayerView();
    }
}
