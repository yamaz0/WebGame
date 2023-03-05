using FluentValidation;
using WebGame.Application.Constants;

namespace WebGame.Application.Functions.Jobs.Command.Create
{
    public class CreateJobCommandValidate : AbstractValidator<CreateJobCommand>
    {
        public CreateJobCommandValidate()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ConstantsEntity.Job.NAME_MAX_LENGHT);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(ConstantsEntity.Job.DESC_MAX_LENGHT);
            RuleFor(x => x.Duration).GreaterThanOrEqualTo(ConstantsEntity.Job.DURATION_MIN);
            RuleFor(x => x.Reward).GreaterThanOrEqualTo(ConstantsEntity.Job.REWARD_MIN);
        }
    }
}
