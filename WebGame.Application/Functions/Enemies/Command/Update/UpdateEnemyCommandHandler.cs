using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Enemies;

namespace WebGame.Application.Functions.Enemys.Command.Update
{
    public class UpdateEnemyCommandHandler : IRequestHandler<UpdateEnemyCommand>
    {
        private readonly IEnemyRepository _enemyRepository;
        private readonly IMapper _mapper;

        public UpdateEnemyCommandHandler(IEnemyRepository enemyRepository, IMapper mapper)
        {
            _enemyRepository = enemyRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEnemyCommand request, CancellationToken cancellationToken)
        {
            var mappedEnemy = _mapper.Map<Enemy>(request);

            await _enemyRepository.UpdateAsync(mappedEnemy);

            return Unit.Value;
        }
    }
}
