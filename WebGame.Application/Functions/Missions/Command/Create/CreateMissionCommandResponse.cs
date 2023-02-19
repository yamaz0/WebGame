using FluentValidation.Results;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.Missions.Command.Create
{
    public class CreateMissionCommandResponse : BasicResponse
    {
        public int? MissionId { get; set; }

        public CreateMissionCommandResponse(ValidationResult result) : base(result)
        {
        }

        public CreateMissionCommandResponse(int? missionId)
        {
            MissionId = missionId;
        }
    }
}
