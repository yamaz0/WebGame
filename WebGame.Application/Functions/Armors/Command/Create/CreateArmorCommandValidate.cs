using FluentValidation;
using WebGame.Application.Constants;
using WebGame.Entities.Items;

namespace WebGame.Application.Functions.Armors.Command.Create
{
    public class CreateArmorCommandValidate : AbstractValidator<CreateArmorCommand>
    {
        public CreateArmorCommandValidate()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ConstantsEntity.Item.NAME_MAX_LENGHT);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(ConstantsEntity.Item.DESC_MAX_LENGHT);
            RuleFor(x => x.Value).GreaterThanOrEqualTo(ConstantsEntity.Item.VALUE_MIN);
            RuleFor(x => x.Defense).GreaterThanOrEqualTo(ConstantsEntity.Item.ATTACK_MIN);
            RuleFor(x => x.ItemType).IsInEnum().NotNull();
        }
    }

}
