using Blazored.LocalStorage;
using System.Net.Http.Headers;
using WebGame.UI.Blazor.Constants;
using WebGame.UI.Blazor.Interfaces.Authorization;

namespace WebGame.UI.Blazor.Services.Authentication
{
    public class AddBearerTokenService : IAddBearerTokenService
    {
        private readonly ILocalStorageService _localStorage;

        public AddBearerTokenService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task AddBearerToken(IClient client)
        {
            if (await _localStorage.ContainKeyAsync(CustomConstants.LocalStorage.TOKEN))
                client.HttpClient.DefaultRequestHeaders.Authorization
                    = new AuthenticationHeaderValue(CustomConstants.Authorization.BEARER, await _localStorage.GetItemAsync<string>(CustomConstants.LocalStorage.TOKEN));
        }
    }
}
