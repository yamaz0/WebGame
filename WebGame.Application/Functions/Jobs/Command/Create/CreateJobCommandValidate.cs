using FluentValidation;
using WebGame.Application.Constants;

namespace WebGame.Application.Functions.Jobs.Command.Create
{
    public class CreateJobCommandValidate : AbstractValidator<CreateJobCommand>
    {
        public CreateJobCommandValidate()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ConstansJob.NAME_MAX_LENGHT);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(ConstansJob.DESC_MAX_LENGHT);
            RuleFor(x => x.Duration).GreaterThanOrEqualTo(ConstansJob.DURATION_MIN);
            RuleFor(x => x.Reward).GreaterThanOrEqualTo(ConstansJob.REWARD_MIN);
        }
    }
}
