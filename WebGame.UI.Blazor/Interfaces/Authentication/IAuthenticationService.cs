namespace WebGame.UI.Blazor.Interfaces.Authorization
{
    public interface IAuthenticationService
    {
        Task<bool> Login(string username, string password);
        Task<bool> Register(string username, string password, string email);
        Task Logout();
        Task<bool> RefreshToken();
    }
}