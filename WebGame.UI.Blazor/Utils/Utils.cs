using Microsoft.AspNetCore.Components.Authorization;
using WebGame.UI.Blazor.Constants;
using WebGame.UI.Blazor.Services.Authentication;

namespace WebGame.UI.Blazor.Utils
{
    public static class Utils
    {
        public static async Task<int> GetPlayerId(CustomAuthenticationStateProvider AuthenticationStateProvider)
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();

            foreach (var claim in authState.User.Claims)
            {

                if (claim.Type == CustomConstants.Claims.PLAYERID)
                {
                    bool canParse = int.TryParse(claim.Value, out int parsedPlayerId);

                    if (canParse)
                        return parsedPlayerId;
                    else
                    {
                        throw new Exception("playerId not found");
                    }
                }
            }

            return -1;
        }
    }
}
