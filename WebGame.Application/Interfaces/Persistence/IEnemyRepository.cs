using WebGame.Application.Interfaces.Persistence.Common;
using WebGame.Entities.Enemies;

namespace WebGame.Application.Interfaces.Persistence
{
    public interface IEnemyRepository : IAsyncRepository<Enemy>
    {
    }
}
