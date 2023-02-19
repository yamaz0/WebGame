using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Enemies;

namespace WebGame.Persistence.EF.Repository
{
    public class EnemyRepository : BaseRepository<Enemy>, IEnemyRepository
    {
        public EnemyRepository(DbGameContext context) : base(context)
        {
        }
    }
}