using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Enemies.Query.GetAllEnemies
{
    public class GetAllEnemiesRequestHandler : IRequestHandler<GetAllEnemiesRequest, List<GetAllEnemiesViewModel>>
    {
        private readonly IEnemyRepository _enemyRepository;
        private readonly IMapper _mapper;

        public GetAllEnemiesRequestHandler(IEnemyRepository EnemyRepository, IMapper mapper)
        {
            _enemyRepository = EnemyRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllEnemiesViewModel>> Handle(GetAllEnemiesRequest request, CancellationToken cancellationToken)
        {
            var enemies = await _enemyRepository.GetAllAsync();
            var enemiesViewModel = _mapper.Map<List<GetAllEnemiesViewModel>>(enemies);
            return enemiesViewModel;
        }
    }
}
