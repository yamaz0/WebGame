using WebGame.Entities.Missions;

namespace WebGame.Services.Mission.Interface
{
    public interface IMissionService
    {
        IEnumerable<Entities.Missions.Mission> GetAllMissions();
    }
}
