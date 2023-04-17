using Blazored.LocalStorage;
using System.Net.Http.Headers;
using WebGame.UI.Blazor.Constants;
using WebGame.UI.Blazor.Interfaces.Authorization;

namespace WebGame.UI.Blazor.Services.Authentication
{
    public class AddBearerTokenService : IAddBearerTokenService
    {
        private const string REFRESH_TOKEN = CustomConstants.LocalStorage.REFRESH_TOKEN;
        private const string TOKEN = CustomConstants.LocalStorage.TOKEN;
        private readonly ILocalStorageService _localStorage;

        public AddBearerTokenService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task AddBearerToken(IClient client)
        {
            if (await _localStorage.ContainKeyAsync(TOKEN))
                client.HttpClient.DefaultRequestHeaders.Authorization
                    = new AuthenticationHeaderValue(CustomConstants.Authorization.BEARER, await _localStorage.GetItemAsync<string>(TOKEN));
        }

        public async Task AddBearerRefreshToken(IClient client)
        {
            if (await _localStorage.ContainKeyAsync(REFRESH_TOKEN))
                client.HttpClient.DefaultRequestHeaders.Authorization
                    = new AuthenticationHeaderValue(CustomConstants.Authorization.BEARER, await _localStorage.GetItemAsync<string>(REFRESH_TOKEN));
        }
    }
}
