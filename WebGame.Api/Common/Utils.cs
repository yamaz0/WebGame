using WebGame.Application.Constants;

namespace WebGame.Api.Common
{
    static public class Utils
    {
        static public int GetPlayerId(System.Security.Claims.ClaimsPrincipal user)
        {
            var playerIdText = user.Claims.Where(c => c.Type == ConstantsAuthorization.Claims.PLAYER_ID)?.FirstOrDefault()?.Value;

            if (playerIdText == null || !Int32.TryParse(playerIdText, out int playerID))
            {
                return -1;
            }

            return playerID;
        }
    }
}
