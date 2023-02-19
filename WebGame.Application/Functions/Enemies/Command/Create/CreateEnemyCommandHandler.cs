using MediatR;
using WebGame.Application.Functions.Enemys.Command;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Enemies;

namespace WebGame.Application.Functions.Enemies.Command.Create
{
    public class CreateEnemyCommandHandler : IRequestHandler<CreateEnemyCommand, CreateEnemyCommandResponse>
    {
        private readonly IEnemyRepository _enemyRepository;

        public CreateEnemyCommandHandler(IEnemyRepository enemyRepository)
        {
            _enemyRepository = enemyRepository;
        }

        public async Task<CreateEnemyCommandResponse> Handle(CreateEnemyCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEnemyCommandValidate();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.IsValid)
            {
                return new CreateEnemyCommandResponse(validatorResult);
            }

            Enemy enemy = new Enemy()
            {
                Name = request.Name,
                HealthPoint = request.HealthPoint,
                Attack = request.Attack,
                CashReward = request.CashReward,
                ExpReward = request.ExpReward
            };

            enemy = await _enemyRepository.AddAsync(enemy);
            return new CreateEnemyCommandResponse(enemy.Id);
        }
    }
}

