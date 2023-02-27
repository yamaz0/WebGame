using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Enemies.Command.Delete
{
    public class DeleteEnemyCommandHandler : IRequestHandler<DeleteEnemyCommand>
    {
        private readonly IEnemyRepository _enemyRepository;

        public DeleteEnemyCommandHandler(IEnemyRepository enemyRepository)
        {
            _enemyRepository = enemyRepository;
        }

        public async Task<Unit> Handle(DeleteEnemyCommand request, CancellationToken cancellationToken)
        {
            var enemyToDelete = await _enemyRepository.GetByIdAsync(request.EnemyId);
            await _enemyRepository.RemoveAsync(enemyToDelete);
            return Unit.Value;
        }
    }
}
