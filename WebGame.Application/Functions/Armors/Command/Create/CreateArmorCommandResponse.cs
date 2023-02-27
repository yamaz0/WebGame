using FluentValidation.Results;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.Armors.Command.Create
{
    public class CreateArmorCommandResponse : BasicResponse
    {
        public int? armorId { get; set; }

        public CreateArmorCommandResponse(ValidationResult result) : base(result)
        {
        }

        public CreateArmorCommandResponse(int? BodyArmorId)
        {
            BodyArmorId = BodyArmorId;
        }
    }

}
