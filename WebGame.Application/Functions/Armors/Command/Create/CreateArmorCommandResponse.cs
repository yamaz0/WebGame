using FluentValidation.Results;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.Armors.Command.Create
{
    public class CreateArmorCommandResponse : BasicResponse
    {
        public int? ArmorId { get; set; }

        public CreateArmorCommandResponse(ValidationResult result) : base(result)
        {
        }

        public CreateArmorCommandResponse(int? armorId)
        {
            ArmorId = armorId;
        }
    }

}
