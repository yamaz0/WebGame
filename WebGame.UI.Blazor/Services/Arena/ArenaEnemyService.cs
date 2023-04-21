using WebGame.UI.Blazor.Interfaces.Arena;
using WebGame.UI.Blazor.Interfaces.Authorization;

namespace WebGame.UI.Blazor.Services.Arena
{
    public class ArenaEnemyService : IArenaEnemyService
    {
        private IAddBearerTokenService _addBearerTokenService;
        private IClient _client;

        public ArenaEnemyService(IClient client, IAddBearerTokenService addBearerTokenService)
        {
            _client = client;
            _addBearerTokenService = addBearerTokenService;
        }

        public async Task<DuelPlayerVsEnemyResponse> Duel(int enemyId)
        {
            await _addBearerTokenService.AddBearerToken(_client);
            return await _client.DuelAsync(enemyId);
        }
    }
}