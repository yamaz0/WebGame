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

        public async Task<BasicResponse> SetMissionToPlayer(int id)
        {
            await _addBearerTokenService.AddBearerToken(_client);
            return await _client.Start2Async(id, CancellationToken.None);
        }

        public async Task<TimeActionResponse> CheckMission()
        {
            await _addBearerTokenService.AddBearerToken(_client);
            return await _client.Check2Async();
        }

        public async Task<BasicResponse> RewardMission()
        {
            await _addBearerTokenService.AddBearerToken(_client);
            return await _client.Reward2Async();
        }
    }
}