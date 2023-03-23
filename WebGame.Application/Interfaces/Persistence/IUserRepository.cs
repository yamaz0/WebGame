using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        Task<CreateUserCommandResponse> AddAsync(UserEntity user, string password);
        Task UpdateAsync(UserEntity user);
        Task RemoveAsync(UserEntity user);
        Task<bool> CheckPassword(UserEntity user, string password);
        Task<List<string>> GetRolesAsync(UserEntity user);
        Task<List<Claim>> GetClaimsAsync(UserEntity user);
        Task AddClaimToUser(UserEntity entity, Claim claim);
    }
}
