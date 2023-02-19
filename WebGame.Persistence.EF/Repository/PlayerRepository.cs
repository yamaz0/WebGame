using WebGame.Application.Interfaces.Persistence;
using WebGame.Domain.Entities.Player;

namespace WebGame.Persistence.EF.Repository
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(DbGameContext context) : base(context)
        {
        }
    }
}