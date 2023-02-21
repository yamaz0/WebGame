using FluentValidation;
using WebGame.Application.Constants;

namespace WebGame.Application.Functions.Missions.Command.Create
{
    public class CreateMissionCommandValidate : AbstractValidator<CreateMissionCommand>
    {
        public CreateMissionCommandValidate()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ConstantsMission.NAME_MAX_LENGHT);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(ConstantsMission.DESC_MAX_LENGHT);
        }
    }
}
