using WebGame.Services.Player.Interface;
using WebGame.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebGame.Services.Player
{
    public class PlayerService : IPlayerService
    {
        private readonly DbGameContext _context;

        public PlayerService(DbGameContext context)
        {
            _context = context;
        }
        public Entities.Player GetPlayer()
        {
            return _context.Players
                .Include( p => p.Helmet)
                .Include( p => p.Armor)
                .Include( p => p.Legs)
                .Include( p => p.Boots)
                .ToList()[0];
        }
    }
}
