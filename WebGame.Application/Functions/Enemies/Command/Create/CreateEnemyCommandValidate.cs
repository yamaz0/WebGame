using FluentValidation;
using WebGame.Application.Constants;

namespace WebGame.Application.Functions.Enemies.Command.Create
{
    public class CreateEnemyCommandValidate : AbstractValidator<CreateEnemyCommand>
    {
        public CreateEnemyCommandValidate()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ConstansEnemy.NAME_MAX_LENGHT);
            RuleFor(x => x.HealthPoint).GreaterThanOrEqualTo(ConstansEnemy.HEALTH_POINT_MIN);
            RuleFor(x => x.Attack).GreaterThanOrEqualTo(ConstansEnemy.ATTACK_MIN);
            RuleFor(x => x.ExpReward).GreaterThanOrEqualTo(ConstansEnemy.EXP_REWARD_MIN);
            RuleFor(x => x.CashReward).GreaterThanOrEqualTo(ConstansEnemy.CASH_REWARD_MIN);
        }
    }
}