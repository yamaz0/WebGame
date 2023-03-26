using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Security.Models;
using WebGame.Domain.Entities.User;

namespace WebGame.Application.Security.Contracts
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> SingIn(UserEntity entity,string password);
        Task SingOut();
    }
}
