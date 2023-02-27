using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Players.Command.Update;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Players.Command.Update
{
    public class UpdatePlayerCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPlayerRepository> _mockPlayerRepository;

        public UpdatePlayerCommandHandlerTest()
        {
            _mockPlayerRepository = PlayerRepositoryMocks.GetPlayerRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = cfg.CreateMapper();
        }

        [Fact]
        public async void UpdatePlayerTest()
        {
            var handler = new UpdatePlayerCommandHandler(_mockPlayerRepository.Object, _mapper);
            var result = await handler.Handle(new UpdatePlayerCommand(), CancellationToken.None);

            result.ShouldBeOfType(typeof(MediatR.Unit));
        }
    }
}
