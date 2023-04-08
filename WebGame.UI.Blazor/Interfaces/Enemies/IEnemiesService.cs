using WebGame.UI.Blazor.ViewModels.Enemies;

namespace WebGame.UI.Blazor.Interfaces.Enemies
{
    public interface IEnemiesService
    {
        Task<ICollection<AllEnemiesBlazorVM>> GetEnemies();
    }
}
