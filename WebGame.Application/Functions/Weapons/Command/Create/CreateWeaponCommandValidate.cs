using FluentValidation;
using WebGame.Application.Constants;

namespace WebGame.Application.Functions.Weapons.Command.Create
{
    public class CreateWeaponCommandValidate : AbstractValidator<CreateWeaponCommand>
    {
        public CreateWeaponCommandValidate()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ConstantsEntity.Item.NAME_MAX_LENGHT);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(ConstantsEntity.Item.DESC_MAX_LENGHT);
            RuleFor(x => x.Value).GreaterThanOrEqualTo(ConstantsEntity.Item.VALUE_MIN);
            RuleFor(x => x.Attack).GreaterThanOrEqualTo(ConstantsEntity.Item.ATTACK_MIN);
            RuleFor(x => x.AttackSpeed).GreaterThanOrEqualTo(ConstantsEntity.Item.ATTACK_SPEED_MIN);
        }
    }
}
