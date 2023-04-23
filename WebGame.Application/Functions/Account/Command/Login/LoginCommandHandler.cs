using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Security.Contracts;

namespace WebGame.Application.Functions.Account.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authorization;

        public LoginCommandHandler(IUserRepository userRepository, IAuthenticationService authorization)
        {
            _userRepository = userRepository;
            _authorization = authorization;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.UserName))
                return new LoginCommandResponse("UserName cannot be empty!");

            var user = await _userRepository.GetByNameAsync(request.UserName);

            if (user != null)
            {
                var response = await _authorization.SingIn(user, request.Password);
                if (response != null)
                    return new LoginCommandResponse(response);
            }

            return new LoginCommandResponse("Wrong username or password!");
        }
    }
}
