using Microsoft.AspNetCore.Components;
using WebGame.UI.Blazor.Interfaces.Authorization;
using WebGame.UI.Blazor.ViewModels.Authentication;

namespace WebGame.UI.Blazor.Pages.Authentication
{
    public partial class Logout
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        protected override async void OnInitialized()
        {
            await AuthenticationService.Logout();
            NavigationManager.NavigateTo("");
        }

    }
}