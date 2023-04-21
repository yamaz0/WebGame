using AutoMapper;
using WebGame.UI.Blazor.Interfaces.Authorization;
using WebGame.UI.Blazor.Interfaces.Players;
using WebGame.UI.Blazor.ViewModels.Players;
using WebGame.UI.Blazor.ViewModels.Weapons;

namespace WebGame.UI.Blazor.Services.Players
{
    public class PlayerServices : IPlayerServices
    {
        private readonly IMapper _mapper;
        private IClient _client;
        private IAddBearerTokenService _addBearerTokenService;

        public PlayerServices(IMapper mapper, IClient client, IAddBearerTokenService addBearerTokenService)
        {
            _mapper = mapper;
            _client = client;
            _addBearerTokenService = addBearerTokenService;
        }

        public async Task<PlayerBlazorVM> GetPlayerView()
        {
            await _addBearerTokenService.AddBearerToken(_client);
            var player = await _client.PlayerGET2Async();
            PlayerBlazorVM mappedPlayer = _mapper.Map<PlayerBlazorVM>(player);
            return mappedPlayer;
        }

        public async Task AddStat(Statistic statistic)
        {
            await _addBearerTokenService.AddBearerToken(_client);
            await _client.AddStatAsync(new AddedStatsPlayerCommand() { Statistic = statistic });
        }

        public async Task<GetPlayerAllInfoViewModel> GetPlayer()
        {
            await _addBearerTokenService.AddBearerToken(_client);
            return await _client.PlayerGET2Async();
        }
    }
}
