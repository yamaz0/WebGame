using FluentValidation;
using WebGame.Application.Constants;

namespace WebGame.Application.Functions.Weapons.Command.Create
{
    public class CreateWeaponCommandValidate : AbstractValidator<CreateWeaponCommand>
    {
        public CreateWeaponCommandValidate()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ConstantsItem.NAME_MAX_LENGHT);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(ConstantsItem.DESC_MAX_LENGHT);
            RuleFor(x => x.Value).GreaterThanOrEqualTo(ConstantsItem.VALUE_MIN);
            RuleFor(x => x.Attack).GreaterThanOrEqualTo(ConstantsItem.ATTACK_MIN);
            RuleFor(x => x.AttackSpeed).GreaterThanOrEqualTo(ConstantsItem.ATTACK_SPEED_MIN);
        }
    }
}
