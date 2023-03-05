using FluentValidation;
using WebGame.Application.Constants;
using WebGame.Domain.Entities.Player;

namespace WebGame.Application.Functions.Players.Command.Create
{
    public class CreatePlayerCommandValidate : AbstractValidator<CreatePlayerCommand>
    {
        public CreatePlayerCommandValidate()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ConstantsEntity.Player.NAME_MAX_LENGHT);
        }
    }
}
