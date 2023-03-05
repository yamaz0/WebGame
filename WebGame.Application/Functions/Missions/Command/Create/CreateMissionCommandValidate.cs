using FluentValidation;
using WebGame.Application.Constants;

namespace WebGame.Application.Functions.Missions.Command.Create
{
    public class CreateMissionCommandValidate : AbstractValidator<CreateMissionCommand>
    {
        public CreateMissionCommandValidate()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ConstantsEntity.Mission.NAME_MAX_LENGHT);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(ConstantsEntity.Mission.DESC_MAX_LENGHT);
        }
    }
}
