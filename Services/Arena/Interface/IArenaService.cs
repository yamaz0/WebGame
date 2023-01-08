using WebGame.Entities.Enemies;

namespace WebGame.Services.Arena.Interface
{
    public interface IArenaService
    {
        IEnumerable<Enemy> GetAllEnemies();
    }
}
