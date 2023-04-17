using WebGame.UI.Blazor.Services;

namespace WebGame.UI.Blazor.Interfaces.Authorization
{
    public interface IAddBearerTokenService
    {
        Task AddBearerRefreshToken(IClient client);
        Task AddBearerToken(IClient client);
    }
}