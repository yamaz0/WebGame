using WebGame.Application.Response;
using WebGame.Application.Security.Models;

namespace WebGame.Application.Functions.Account.Command.Login
{
    public class LoginCommandResponse : BasicResponse
    {
        public AuthenticationResponse AuthenticationResponse { get; set; }

        public LoginCommandResponse(AuthenticationResponse authenticationResponse) : base(true)
        {
            AuthenticationResponse = authenticationResponse;
        }

        public LoginCommandResponse(string error) : base(error)
        {

        }
    }
}
