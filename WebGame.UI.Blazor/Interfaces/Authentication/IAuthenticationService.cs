using WebGame.UI.Blazor.Services;

namespace WebGame.UI.Blazor.Interfaces.Authorization
{
    public interface IAuthenticationService
    {
        Task<LoginCommandResponse> Login(string username, string password);
        Task<CreateUserCommandResponse> Register(string username, string password, string email);
        Task Logout();
        Task<bool> RefreshToken();
    }
}