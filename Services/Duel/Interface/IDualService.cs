using WebGame.Models;

namespace WebGame.Services.Duel.Interface
{
    public interface IDualService
    {
        public DuelData DuelEnemy(int enemyId);
        public DuelData DuelPlayer(int playerId);
    }
}
