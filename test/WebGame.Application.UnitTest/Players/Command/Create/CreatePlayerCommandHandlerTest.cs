using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Players.Command.Create;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Players.Command.Create
{
    public class CreatePlayerCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPlayerRepository> _mockPlayerRepository;

        public CreatePlayerCommandHandlerTest()
        {
            _mockPlayerRepository = PlayerRepositoryMocks.GetPlayerRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = cfg.CreateMapper();
        }

        [Fact]
        public async void CreatePlayerTest()
        {
            var handler = new CreatePlayerCommandHandler(_mockPlayerRepository.Object);
            var result = await handler.Handle(new CreatePlayerCommand(), CancellationToken.None);

            result.ShouldBeOfType(typeof(CreatePlayerCommandResponse));
        }
    }
}
