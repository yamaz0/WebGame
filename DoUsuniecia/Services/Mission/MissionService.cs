using WebGame.Services.Mission.Interface;
using WebGame.Entities.Missions;

namespace WebGame.Services.Mission
{
    public class MissionService : IMissionService
    {
        private readonly DbGameContext _context;

        public MissionService(DbGameContext context)
        {
            _context = context;
        }
        public IEnumerable<Entities.Missions.Mission> GetAllMissions()
        {
            return _context.Missions.ToList();
        }
    }
}
