using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Functions.Accounts.Command.Create;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Users
{
    public class RegisterUserTest
    {
        private const string EMAIL_SUCCESFUL = "a@b.com";
        private const string PASSWORD_SUCCESFULL = "P@$$w0rD";
        private const string USERNAME_SUCCESFUL = "CreateUserCommand";

        private readonly Mock<IPlayerRepository> _playerRepository;
        private readonly Mock<IUserRepository> _userRepository;
        public RegisterUserTest()
        {
            _playerRepository = PlayerRepositoryMocks.GetPlayerRepository();
            _userRepository = UserRepositoryMocks.GetUsersRepository();
        }

        [Fact]
        public async Task Register_User_Command_Should_Be_Succesfull()
        {
            var request = new CreateUserCommand() { Email = EMAIL_SUCCESFUL, Password = PASSWORD_SUCCESFULL, Username = USERNAME_SUCCESFUL };
            var handler = new CreateUserCommandHandler(_playerRepository.Object, _userRepository.Object);
            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType(typeof(CreateUserCommandResponse));
        }
    }
}
