using WebGame.Entities.Enemies;
using WebGame.Services.Arena.Interface;

namespace WebGame.Services.Arena
{
    public class ArenaService : IArenaService
    {
        private readonly DbGameContext _context;

        public ArenaService(DbGameContext context)
        {
            _context = context;
        }
        public IEnumerable<Enemy> GetAllEnemies()
        {
            return _context.Enemies.ToList();
        }
    }
}
