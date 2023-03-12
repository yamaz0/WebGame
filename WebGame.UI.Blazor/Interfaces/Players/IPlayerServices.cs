using WebGame.UI.Blazor.ViewModels.Players;

namespace WebGame.UI.Blazor.Interfaces.Players
{
    public interface IPlayerServices
    {
        Task<PlayerBlazorVM> GetPlayer();
    }
}
