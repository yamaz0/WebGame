using AutoMapper;
using WebGame.UI.Blazor.Interfaces.Players;
using WebGame.UI.Blazor.ViewModels.Players;
using WebGame.UI.Blazor.ViewModels.Weapons;

namespace WebGame.UI.Blazor.Services.Players
{
    public class PlayerServices : IPlayerServices
    {
        private readonly IMapper _mapper;
        private IClient _client;

        public PlayerServices(IMapper mapper, IClient client)
        {
            _mapper = mapper;
            _client = client;
        }

        public async Task<PlayerBlazorVM> GetPlayer()
        {
            var player = await _client.PlayerAsync(1);
            PlayerBlazorVM mappedPlayer = _mapper.Map<PlayerBlazorVM>(player);
            return mappedPlayer;
        }
    }
}
