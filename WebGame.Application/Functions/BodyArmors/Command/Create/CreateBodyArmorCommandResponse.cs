using FluentValidation.Results;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.BodyArmors.Command.Create
{
    public class CreateBodyArmorCommandResponse : BasicResponse
    {
        public int? bodyArmorId { get; set; }

        public CreateBodyArmorCommandResponse(ValidationResult result) : base(result)
        {
        }

        public CreateBodyArmorCommandResponse(int? BodyArmorId)
        {
            BodyArmorId = BodyArmorId;
        }
    }

}
