using AutoMapper;
using WebGame.UI.Blazor.Interfaces.Authorization;
using WebGame.UI.Blazor.Interfaces.Jobs;
using WebGame.UI.Blazor.Interfaces.Missions;
using WebGame.UI.Blazor.Interfaces.Players;
using WebGame.UI.Blazor.ViewModels.Missions;
using WebGame.UI.Blazor.ViewModels.Players;
using WebGame.UI.Blazor.ViewModels.Weapons;

namespace WebGame.UI.Blazor.Services.Missions
{
    public class JobServices : IJobServices
    {
        private IClient _client;
        private IAddBearerTokenService _addBearerTokenService;

        public JobServices( IClient client, IAddBearerTokenService addBearerTokenService)
        {
            _client = client;
            _addBearerTokenService = addBearerTokenService;
        }

        public async Task<BasicResponse> SetJobToPlayer(int duration)
        {
            await _addBearerTokenService.AddBearerToken(_client);
            return await _client.StartAsync(duration, CancellationToken.None);
        }

        public async Task<TimeActionResponse> CheckJob()
        {
            await _addBearerTokenService.AddBearerToken(_client);
            return await _client.CheckAsync();
        }

        public async Task<BasicResponse> RewardJob()
        {
            await _addBearerTokenService.AddBearerToken(_client);
            return await _client.RewardAsync();
        }
    }
}