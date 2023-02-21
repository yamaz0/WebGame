using FluentValidation;
using WebGame.Application.Constants;

namespace WebGame.Application.Functions.Jobs.Command.Create
{
    public class CreateJobCommandValidate : AbstractValidator<CreateJobCommand>
    {
        public CreateJobCommandValidate()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ConstantsJob.NAME_MAX_LENGHT);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(ConstantsJob.DESC_MAX_LENGHT);
            RuleFor(x => x.Duration).GreaterThanOrEqualTo(ConstantsJob.DURATION_MIN);
            RuleFor(x => x.Reward).GreaterThanOrEqualTo(ConstantsJob.REWARD_MIN);
        }
    }
}
