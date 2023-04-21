using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using WebGame.UI.Blazor.Constants;
using WebGame.UI.Blazor.Interfaces.Authorization;

namespace WebGame.UI.Blazor.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly IClient _client;
        private readonly ILocalStorageService _localStorage;
        private IAddBearerTokenService _addBearerTokenService;

        public AuthenticationService(IClient client, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider, IAddBearerTokenService addBearerTokenService)
        {
            _client = client;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
            _addBearerTokenService = addBearerTokenService;
        }

        public async Task<bool> Login(string username, string password)
        {
            LoginCommand request = new LoginCommand() { Password = password, UserName = username };
            var response = await _client.LoginAsync(request);

            string accessToken = response.AuthenticationResponse.AccessToken;
            string refreshToken = response.AuthenticationResponse.RefreshToken;

            if (accessToken != string.Empty)
            {
                await _localStorage.SetItemAsync(CustomConstants.LocalStorage.TOKEN, accessToken);
                await _localStorage.SetItemAsync(CustomConstants.LocalStorage.REFRESH_TOKEN, refreshToken);

                ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserAuthenticated(username);
                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(CustomConstants.Authorization.BEARER, accessToken);
                return true;
            }

            return false;
        }

        public async Task<bool> RefreshToken()
        {
            await _addBearerTokenService.AddBearerRefreshToken(_client);
            var response = await _client.RefreshTokenAsync();

            string accessToken = response.RefreshTokenResponse.AccessToken;
            string refreshToken = response.RefreshTokenResponse.RefreshToken;

            if (accessToken != string.Empty)
            {
                await _localStorage.SetItemAsync(CustomConstants.LocalStorage.TOKEN, accessToken);
                await _localStorage.SetItemAsync(CustomConstants.LocalStorage.REFRESH_TOKEN, refreshToken);

                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(CustomConstants.Authorization.BEARER, accessToken);
                return true;
            }

            return false;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync(CustomConstants.LocalStorage.TOKEN);
            await _localStorage.RemoveItemAsync(CustomConstants.LocalStorage.REFRESH_TOKEN);
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserLoggedOut();
            _client.HttpClient.DefaultRequestHeaders.Authorization = null;
            //await _client.LogoutAsync();
        }

        public async Task<bool> Register(string username, string password, string email)
        {
            CreateUserCommand registrationRequest = new CreateUserCommand() { Email = email, Username = username, Password = password };
            var response = await _client.RegisterAsync(registrationRequest);

            if (!string.IsNullOrEmpty(response.Id))
            {
                return true;
            }

            return false;
        }
    }
}