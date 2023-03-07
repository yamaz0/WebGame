using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.Account.Command
{
    public class LoginCommand : IRequest<LoginCommandResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public LoginCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByNameAsync(request.UserName);

            if (user != null)
            {
                bool isPasswordCorrect = await _userRepository.CheckPassword(user, request.Password);

                if (isPasswordCorrect)
                {

                    return new LoginCommandResponse();
                }
            }

            return new LoginCommandResponse("Wrong username or password!");
        }
    }

    public class LoginCommandResponse : BasicResponse
    {
        //tutaj bedzie Json token coś tam

        public LoginCommandResponse() : base(true)
        {

        }

        public LoginCommandResponse(string error) : base(error)
        {

        }
    }
}
