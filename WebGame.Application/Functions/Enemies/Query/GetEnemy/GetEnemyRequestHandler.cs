using AutoMapper;
using MediatR;
using WebGame.Application.Functions.Enemies.Query.GetBodyArmor;
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

        public async Task<GetEnemyViewModel> Handle(GetEnemyRequest request, CancellationToken cancellationToken)
        {
            var enemy = await _enemyRepository.GetByIdAsync(request.EnemyId);
            var mappedEnemy = _mapper.Map<GetEnemyViewModel>(enemy);
            return mappedEnemy;
            
        }

    }
}
