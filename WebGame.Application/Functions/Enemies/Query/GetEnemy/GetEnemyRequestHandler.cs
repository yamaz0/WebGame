using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Enemies.Query.GetEnemy
{
    public class GetEnemyRequestHandler : IRequestHandler<GetEnemyRequest, GetEnemyViewModel>
    {
        private readonly IEnemyRepository _enemyRepository;
        private readonly IMapper _mapper;

        public GetEnemyRequestHandler(IEnemyRepository enemyRepository, IMapper mapper)
        {
            _enemyRepository = enemyRepository;
            _mapper = mapper;
        }

        public async Task<GetBodyArmorViewModel> Handle(GetEnemyRequest request, CancellationToken cancellationToken)
        {
            var enemy = await _enemyRepository.GetByIdAsync(request.EnemyId);
            var mappedEnemy = _mapper.Map<GetBodyArmorViewModel>(enemy);
            return mappedEnemy;
        }
    }
}
