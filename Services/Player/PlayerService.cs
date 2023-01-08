using WebGame.Services.Player.Interface;
using WebGame.Entities;

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
            return _context.Players.ToList()[0];
        }
    }
}
