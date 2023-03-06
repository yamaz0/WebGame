using FluentValidation.Results;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.Players.Command.Create
{
    public class CreatePlayerCommandResponse : BasicResponse
    {
        public int? PlayerId { get; set; }

        public CreatePlayerCommandResponse(ValidationResult result) : base(result)
        {
        }

        public CreatePlayerCommandResponse(int? playerId)
        {
            PlayerId = playerId;
        }
    }
}
