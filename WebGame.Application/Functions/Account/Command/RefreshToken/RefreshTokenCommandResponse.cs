using WebGame.Application.Response;
using WebGame.Application.Security.Models;

namespace WebGame.Application.Functions.Account.Command.RefreshToken
{
    public class RefreshTokenCommandResponse : BasicResponse
    {
        public RefreshTokenResponse RefreshTokenResponse { get; set; }

        public RefreshTokenCommandResponse(RefreshTokenResponse refreshTokenResponse) : base(true)
        {
            RefreshTokenResponse = refreshTokenResponse;
        }

        public RefreshTokenCommandResponse(string error) : base(error)
        {

        }
    }
}
