using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Security.Contracts;

namespace WebGame.Application.Functions.Account.Command.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
    {
        private readonly IAuthenticationService _authenticationService;

        public LogoutCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await _authenticationService.SingOut();
            return Unit.Value;
        }
    }
}