using AutoMapper;
using WebGame.UI.Blazor.Interfaces.Authorization;
using WebGame.UI.Blazor.Interfaces.Enemies;
using WebGame.UI.Blazor.ViewModels.Enemies;

namespace WebGame.UI.Blazor.Services.Enemies
{
    public class EnemiesService : IEnemiesService
    {
        private IAddBearerTokenService _addBearerTokenService;
        private readonly IMapper _mapper;
        private IClient _client;

        public EnemiesService(IMapper mapper, IClient client, IAddBearerTokenService addBearerTokenService)
        {
            _mapper = mapper;
            _client = client;
            _addBearerTokenService = addBearerTokenService;
        }

        public async Task<ICollection<AllEnemiesBlazorVM>> GetEnemies()
        {
            await _addBearerTokenService.AddBearerToken(_client);
            var enemies = await _client.EnemiesAllAsync();
            var mappedEnemies = _mapper.Map<ICollection<AllEnemiesBlazorVM>>(enemies);

            return mappedEnemies;
        }
    }
}
