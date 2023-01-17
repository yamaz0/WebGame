using WebGame.Entities;

namespace WebGame.Services.Player.Interface
{
    public interface IPlayerService
    {
        Entities.Player GetPlayer(string userId);
    }
}