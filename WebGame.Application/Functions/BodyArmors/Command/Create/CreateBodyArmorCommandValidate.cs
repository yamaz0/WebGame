using FluentValidation;
using WebGame.Application.Constants;
using WebGame.Entities.Items;

namespace WebGame.Application.Functions.BodyArmors.Command.Create
{
    public class CreateBodyArmorCommandValidate : AbstractValidator<CreateBodyArmorCommand>
    {
        public CreateBodyArmorCommandValidate()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ConstansItem.NAME_MAX_LENGHT);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(ConstansItem.DESC_MAX_LENGHT);
            RuleFor(x => x.Value).GreaterThanOrEqualTo(ConstansItem.VALUE_MIN);
            RuleFor(x => x.Defense).GreaterThanOrEqualTo(ConstansItem.ATTACK_MIN);
            RuleFor(x => x.ItemType).IsInEnum().NotNull();
        }
    }

}
