using WebGame.UI.Blazor.Services;

namespace WebGame.UI.Blazor.Interfaces.Authorization
{
    public interface IAddBearerTokenService
    {
        Task AddBearerToken(IClient client);
    }
}