using FluentValidation;
using WebGame.Application.Constants;
using WebGame.Entities.Items;

namespace WebGame.Application.Functions.BodyArmors.Command.Create
{
    public class CreateBodyArmorCommandValidate : AbstractValidator<CreateBodyArmorCommand>
    {
        public CreateBodyArmorCommandValidate()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ConstantsItem.NAME_MAX_LENGHT);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(ConstantsItem.DESC_MAX_LENGHT);
            RuleFor(x => x.Value).GreaterThanOrEqualTo(ConstantsItem.VALUE_MIN);
            RuleFor(x => x.Defense).GreaterThanOrEqualTo(ConstantsItem.ATTACK_MIN);
            RuleFor(x => x.ItemType).IsInEnum().NotNull();
        }
    }

}
