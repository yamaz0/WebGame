using WebGame.Application.Response;

namespace WebGame.Application.Functions.Missions.Command
{
    public class CheckMissionCommandResponse : BasicResponse
    {
        public bool IsMissionFinished { get; set; }
        public bool HasPlayerMission { get; set; }
        public DateTime MissionEndTime { get; set; }
    }
}
