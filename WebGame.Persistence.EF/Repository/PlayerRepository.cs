using Microsoft.EntityFrameworkCore;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Domain.Entities.Player;

namespace WebGame.Persistence.EF.Repository
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(DbGameContext context) : base(context)
        {
        }

        public async Task<Player> GetFullByIdAsync(int id)
        {
            var player = await _context.Players
                .Where(p => p.Id == id)
                .Include(p => p.Helmet)
                .Include(p => p.Armor)
                .Include(p => p.Legs)
                .Include(p => p.Boots)
                .Include(p => p.Weapon)
                .FirstOrDefaultAsync();

            if (player == null)
            {
                return null;
            }

            return player;
        }
    }
}