using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Security.Contracts;

namespace WebGame.Application.Functions.Account.Command.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authorization;

        public RefreshTokenCommandHandler(IUserRepository userRepository, IAuthenticationService authorization)
        {
            _userRepository = userRepository;
            _authorization = authorization;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserAsync(request.Principal);

            if (user != null)
            {
                var response = await _authorization.RefreshToken(user);
                if (response != null)
                    return new RefreshTokenCommandResponse(response);
            }

            return new RefreshTokenCommandResponse("User not found!");
        }
    }
}
