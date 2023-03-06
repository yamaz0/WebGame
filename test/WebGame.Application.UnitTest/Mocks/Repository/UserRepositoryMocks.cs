using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using System.Threading.Tasks;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Domain.Entities.User;
using WebGame.Application.Functions.Accounts.Command.Create;

namespace WebGame.Application.UnitTest.Mocks.Repository
{
    internal static class UserRepositoryMocks
    {
        public static Mock<IUserRepository> GetUsersRepository()
        {
            Mock<IUserRepository> userRepositoryMocks = new Mock<IUserRepository>();
            List<UserEntity> users = GetUsers();

            userRepositoryMocks.Setup(x => x.AddAsync(It.IsAny<UserEntity>(), It.IsAny<string>())).ReturnsAsync(
                (UserEntity userEntity, string password) =>
                {
                    users.Add(userEntity);
                    return new CreateUserCommandResponse(new Microsoft.AspNetCore.Identity.IdentityResult(), userEntity.Id) { Success = true };
                });

            return userRepositoryMocks;
        }

        private static List<UserEntity> GetUsers()
        {
            return new List<UserEntity>
            {
                new UserEntity()
                {
                    Id = "ID",
                    UserName= "Test",
                    Email ="test@test.com"
                }
            };
        }
    }
}
