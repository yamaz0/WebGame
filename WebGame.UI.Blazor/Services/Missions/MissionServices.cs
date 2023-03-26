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

        public async Task<GetPlayerAllInfoViewModel> SetMissionToPlayer(int id, DateTime endTime)
        {
            var player = await _playerServices.GetPlayer();
            player.MissionId = id;
            player.EndMissionTime = endTime;
            await UpdatePlayer(player);
            return player;
        }

        private async Task UpdatePlayer(GetPlayerAllInfoViewModel player)
        {
            var mappedPlayercommand = _mapper.Map<UpdatePlayerCommand>(player);

            await _addBearerTokenService.AddBearerToken(_client);
            await _client.PlayerPUTAsync(mappedPlayercommand);
        }

        public async Task RewardPlayer(GetPlayerAllInfoViewModel player)
        {
            var mission = await _client.MissionsGETAsync(player.MissionId);

            player.Exp += mission.Reward;
            player.MissionId = 0;

            await UpdatePlayer(player);
        }
    }
}