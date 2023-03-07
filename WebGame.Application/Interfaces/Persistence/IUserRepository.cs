using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Functions.Accounts.Command.Create;
using WebGame.Application.Interfaces.Persistence.Common;
using WebGame.Domain.Entities.User;

namespace WebGame.Application.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<UserEntity> GetByIdAsync(string id);
        Task<UserEntity> GetByNameAsync(string name);
        Task<IReadOnlyList<UserEntity>> GetAllAsync();
        Task<CreateUserCommandResponse> AddAsync(UserEntity entity, string password);
        Task UpdateAsync(UserEntity entity);
        Task RemoveAsync(UserEntity entity);
        Task<bool> CheckPassword(UserEntity entity, string password);
        Task SingIn(UserEntity entity);
    }
}
