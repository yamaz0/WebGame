using FluentValidation;
using WebGame.Application.Constants;

namespace WebGame.Application.Functions.Enemies.Command.Create
{
    public class CreateEnemyCommandValidate : AbstractValidator<CreateEnemyCommand>
    {
        public CreateEnemyCommandValidate()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ConstantsEntity.Enemy.NAME_MAX_LENGHT);
            RuleFor(x => x.HealthPoint).GreaterThanOrEqualTo(ConstantsEntity.Enemy.HEALTH_POINT_MIN);
            RuleFor(x => x.Attack).GreaterThanOrEqualTo(ConstantsEntity.Enemy.ATTACK_MIN);
            RuleFor(x => x.ExpReward).GreaterThanOrEqualTo(ConstantsEntity.Enemy.EXP_REWARD_MIN);
            RuleFor(x => x.CashReward).GreaterThanOrEqualTo(ConstantsEntity.Enemy.CASH_REWARD_MIN);
        }
    }
}