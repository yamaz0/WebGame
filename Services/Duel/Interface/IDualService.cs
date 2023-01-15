using WebGame.Models;

namespace WebGame.Services.Duel.Interface
{
    public interface IDualService
    {
        public DuelData DuelEnemy(string userId, int enemyId);
        public DuelData DuelPlayer(string userId, int playerId);
    }
}
