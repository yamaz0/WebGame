using Microsoft.AspNetCore.Components;
using System.Text;
using WebGame.UI.Blazor.Interfaces.Authorization;
using WebGame.UI.Blazor.Services;
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
            Message = "Loading...";

            var response = await AuthenticationService.Login(LoginViewModel.UserName, LoginViewModel.Password);
            if (response.Success)
            {
                NavigationManager.NavigateTo("shop");
            }
            ShowErrors(response);
        }

        private void ShowErrors(LoginCommandResponse? response)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var error in response.Errors)
            {
                sb.AppendLine(error);
            }

            Message = sb.ToString();
            StateHasChanged();
        }
    }
}