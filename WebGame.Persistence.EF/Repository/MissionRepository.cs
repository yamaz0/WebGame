using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Missions;

namespace WebGame.Persistence.EF.Repository
{
    public class MissionRepository : BaseRepository<Mission>, IMissionRepository
    {
        public MissionRepository(DbGameContext context) : base(context)
        {
        }
    }
}