using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using WebGame.UI.Blazor.Services.Authentication;

namespace WebGame.UI.Blazor.Pages.ShopPages
{
    public partial class Shop
    {

        [CascadingParameter]
        private Task<AuthenticationState>? authenticationState { get; set; }

        private string? authMessage;
        private string? surname;
        private IEnumerable<Claim> claims = Enumerable.Empty<Claim>();

        private async Task GetClaimsPrincipalData()
        {
            var authState = await ((CustomAuthenticationStateProvider)AuthenticationStateProvider)
                .GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity is not null && user.Identity.IsAuthenticated)
            {
                authMessage = $"{user.Identity.Name} is authenticated.";
                claims = user.Claims;
                surname = user.FindFirst(c => c.Type == ClaimTypes.Surname)?.Value;
            }
            else
            {
                authMessage = "The user is NOT authenticated.";
            }
        }

        protected override async Task OnInitializedAsync()
        {
            //if (authenticationState is not null)
            //{
            //    var authState = await authenticationState;
            //    var user = authState?.User;

            //    if (user?.Identity is not null && user.Identity.IsAuthenticated)
            //    {
            //        authMessage = $"{user.Identity.Name} is authenticated.";
            //    }
            //}
        }
    }
}
