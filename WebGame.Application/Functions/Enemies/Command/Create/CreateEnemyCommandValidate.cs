using FluentValidation;
using WebGame.Application.Constants;

namespace WebGame.Application.Functions.Enemies.Command.Create
{
    public class CreateEnemyCommandValidate : AbstractValidator<CreateEnemyCommand>
    {
        public CreateEnemyCommandValidate()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ConstantsEnemy.NAME_MAX_LENGHT);
            RuleFor(x => x.HealthPoint).GreaterThanOrEqualTo(ConstantsEnemy.HEALTH_POINT_MIN);
            RuleFor(x => x.Attack).GreaterThanOrEqualTo(ConstantsEnemy.ATTACK_MIN);
            RuleFor(x => x.ExpReward).GreaterThanOrEqualTo(ConstantsEnemy.EXP_REWARD_MIN);
            RuleFor(x => x.CashReward).GreaterThanOrEqualTo(ConstantsEnemy.CASH_REWARD_MIN);
        }
    }
}