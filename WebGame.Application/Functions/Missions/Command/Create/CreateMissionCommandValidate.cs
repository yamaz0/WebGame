using FluentValidation;
using WebGame.Application.Constants;

namespace WebGame.Application.Functions.Missions.Command.Create
{
    public class CreateMissionCommandValidate : AbstractValidator<CreateMissionCommand>
    {
        public CreateMissionCommandValidate()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ConstansItem.NAME_MAX_LENGHT);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(ConstansItem.DESC_MAX_LENGHT);
            RuleFor(x => x.Value).GreaterThanOrEqualTo(ConstansItem.VALUE_MIN);
            RuleFor(x => x.Attack).GreaterThanOrEqualTo(ConstansItem.ATTACK_MIN);
            RuleFor(x => x.AttackSpeed).GreaterThanOrEqualTo(ConstansItem.ATTACK_SPEED_MIN);
        }
    }
}
