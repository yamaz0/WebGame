using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Constants;
using WebGame.Application.Functions.Accounts.Command.Create;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Domain.Entities.User;

namespace WebGame.Persistence.EF.Account
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<UserEntity> _userManager;


        public UserRepository(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> AddAsync(UserEntity entity, string password)
        {
            var result = await _userManager.CreateAsync(entity, password);

            await _userManager.AddToRoleAsync(entity, ConstantsAuthorization.Roles.PLAYER);

            return new CreateUserCommandResponse(result, entity.Id);
        }

        public async Task<bool> CheckPassword(UserEntity entity, string password)
        {
            return await _userManager.CheckPasswordAsync(entity, password);
        }

        public async Task<IReadOnlyList<UserEntity>> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<UserEntity> GetByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<UserEntity> GetByNameAsync(string name)
        {
            return await _userManager.FindByNameAsync(name);
        }

        public async Task<List<Claim>> GetClaimsAsync(UserEntity user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            return claims.ToList();
        }

        public async Task<List<string>> GetRolesAsync(UserEntity user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles.ToList();
        }

        public async Task RemoveAsync(UserEntity entity)
        {
            await _userManager.DeleteAsync(entity);
        }

        public async Task UpdateAsync(UserEntity entity)
        {
            await _userManager.UpdateAsync(entity);
        }

    }
}