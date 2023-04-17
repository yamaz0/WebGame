using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebGame.Domain.Entities.User;

namespace WebGame.Application.Functions.Account.Command.RefreshToken
{
    public class RefreshTokenCommand : IRequest<RefreshTokenCommandResponse>
    {
        public ClaimsPrincipal Principal { get; set; }

        public RefreshTokenCommand(ClaimsPrincipal principal)
        {
            Principal = principal;
        }
    }
}
