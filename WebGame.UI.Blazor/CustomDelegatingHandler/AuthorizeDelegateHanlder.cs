using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components;
using WebGame.UI.Blazor.Interfaces.Authorization;

namespace WebGame.UI.Blazor.CustomDelegatingHandler
{
    public class AuthorizeDelegateHanlder : DelegatingHandler
    {
        private readonly string host;
        readonly NavigationManager _navigationManager;
        readonly IAuthenticationService _authenticationService;

        public AuthorizeDelegateHanlder(IWebAssemblyHostEnvironment webAssemblyHostEnvironment, NavigationManager navigationManager, IAuthenticationService authenticationService)
        {
            host = webAssemblyHostEnvironment.BaseAddress;
            _navigationManager = navigationManager;
            _authenticationService = authenticationService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                Console.WriteLine("CustomMessageHandler catch 401");

                // TODO: some logic (e.g. refreshing token)
                bool hasTokenRefreshed = await _authenticationService.RefreshToken();

                if (!hasTokenRefreshed)
                {
                    _navigationManager.NavigateTo("/login", true);
                }
            }

            return response;
        }
    }
}
