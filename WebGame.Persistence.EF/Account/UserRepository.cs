using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Functions.Accounts.Command.Create;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Domain.Entities.User;

namespace WebGame.Persistence.EF.Account
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<UserEntity> _userManager;

        public UserRepository(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> AddAsync(UserEntity entity, string password)
        {

            var result = await _userManager.CreateAsync(entity, password);
            return new CreateUserCommandResponse(result, entity.Id);
        }

        public async Task<IReadOnlyList<UserEntity>> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<UserEntity> GetByIdAsync(string id)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
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