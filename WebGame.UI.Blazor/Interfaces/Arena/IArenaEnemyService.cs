using WebGame.UI.Blazor.Services;

namespace WebGame.UI.Blazor.Interfaces.Arena
{
    public interface IArenaEnemyService
    {
        Task<DuelPlayerVsEnemyResponse> Duel(int id);
    }
}
