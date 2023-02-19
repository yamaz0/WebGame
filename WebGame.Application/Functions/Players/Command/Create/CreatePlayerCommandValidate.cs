using FluentValidation;
using WebGame.Application.Constants;

namespace WebGame.Application.Functions.Players.Command.Create
{
    public class CreatePlayerCommandValidate : AbstractValidator<CreatePlayerCommand>
    {
        public CreatePlayerCommandValidate()
        {

        }
    }
}
