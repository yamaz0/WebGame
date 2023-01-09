using WebGame.Models;

namespace WebGame.Services.Duel.Interface
{
    public interface IDualService
    {
        public DuelData Duel(int enemyId);
    }
}
