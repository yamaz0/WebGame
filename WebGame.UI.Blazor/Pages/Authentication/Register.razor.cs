using Microsoft.AspNetCore.Components;
using System.Text;
using WebGame.UI.Blazor.Interfaces.Authorization;
using WebGame.UI.Blazor.Services;
using WebGame.UI.Blazor.ViewModels.Authentication;

namespace WebGame.UI.Blazor.Pages.Authentication
{
    public partial class Register
    {
        public RegisterBlazorVM RegisterViewModel { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        protected override void OnInitialized()
        {
            RegisterViewModel = new RegisterBlazorVM();
        }

        protected async void HandleValidSubmit()
        {
            var response = await AuthenticationService.Register(RegisterViewModel.UserName, RegisterViewModel.Password, RegisterViewModel.Email);

            if (response is null)
            {
                Message = "Something goes wrong. Try again.";
            }
            else if (response.Success)
            {
                NavigationManager.NavigateTo("home");
            }

            ShowErrors(response);
        }

        private void ShowErrors(CreateUserCommandResponse? response)
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