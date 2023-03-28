using AutoMapper;
using WebGame.UI.Blazor.Interfaces.Authorization;
using WebGame.UI.Blazor.Interfaces.Missions;
using WebGame.UI.Blazor.Interfaces.Players;
using WebGame.UI.Blazor.ViewModels.Missions;
using WebGame.UI.Blazor.ViewModels.Players;
using WebGame.UI.Blazor.ViewModels.Weapons;

namespace WebGame.UI.Blazor.Services.Missions
{
    public class MissionServices : IMissionServices
    {
        private readonly IMapper _mapper;
        private IClient _client;
        private IAddBearerTokenService _addBearerTokenService;
        private IPlayerServices _playerServices;

        public MissionServices(IMapper mapper, IClient client, IAddBearerTokenService addBearerTokenService, IPlayerServices playerServices)
        {
            _mapper = mapper;
            _client = client;
            _addBearerTokenService = addBearerTokenService;
            _playerServices = playerServices;
        }

        public async Task<ICollection<MissionBlazorVM>> GetMissions()
        {
            var missions = await _client.MissionsAllAsync();
            var mappedMissions = _mapper.Map<ICollection<MissionBlazorVM>>(missions);
            return mappedMissions;
        }

        public async Task<StartMissionCommandResponse> SetMissionToPlayer(int id)
        {
            await _addBearerTokenService.AddBearerToken(_client);
            return await _client.StartAsync(id, CancellationToken.None);
        }

        public async Task<CheckMissionCommandResponse> CheckMission()
        {
            await _addBearerTokenService.AddBearerToken(_client);
            return await _client.CheckAsync();
        }
    }
}