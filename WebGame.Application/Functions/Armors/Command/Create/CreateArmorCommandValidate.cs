using FluentValidation;
using WebGame.Application.Constants;
using WebGame.Entities.Items;

namespace WebGame.Application.Functions.Armors.Command.Create
{
    public class CreateArmorCommandValidate : AbstractValidator<CreateArmorCommand>
    {
        public CreateArmorCommandValidate()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ConstantsItem.NAME_MAX_LENGHT);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(ConstantsItem.DESC_MAX_LENGHT);
            RuleFor(x => x.Value).GreaterThanOrEqualTo(ConstantsItem.VALUE_MIN);
            RuleFor(x => x.Defense).GreaterThanOrEqualTo(ConstantsItem.ATTACK_MIN);
            RuleFor(x => x.ItemType).IsInEnum().NotNull();
        }
    }

}
