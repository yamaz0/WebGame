using Microsoft.AspNetCore.Components;
using WebGame.UI.Blazor.Interfaces.Authorization;
using WebGame.UI.Blazor.ViewModels.Authentication;

namespace WebGame.UI.Blazor.Pages.Authentication
{
    public partial class Login
    {
        public LoginBlazorVM LoginViewModel { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        protected override void OnInitialized()
        {
            LoginViewModel = new LoginBlazorVM();
        }

        protected async void HandleValidSubmit()
        {
            if (await AuthenticationService.Login(LoginViewModel.UserName, LoginViewModel.Password))
            {
                NavigationManager.NavigateTo("shop");
            }
            Message = "Username/password not correct";
        }
    }
}