using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Players.Command.Delete;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Players.Command.Delete
{
    public class DeletePlayerCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPlayerRepository> _mockPlayerRepository;

        public DeletePlayerCommandHandlerTest()
        {
            _mockPlayerRepository = PlayerRepositoryMocks.GetPlayerRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = cfg.CreateMapper();
        }

        [Fact]
        public async void DeletePlayerTest()
        {            
            var handler = new DeletePlayerCommandHandler(_mockPlayerRepository.Object);
            int playersCountBefore = (await _mockPlayerRepository.Object.GetAllAsync()).Count;
            var request = new DeletePlayerCommand()
            {
                PlayerId = 1
            };

            var response = await handler.Handle(request, CancellationToken.None);

            int playersCountAfter = (await _mockPlayerRepository.Object.GetAllAsync()).Count;

            playersCountAfter.ShouldBe(playersCountBefore - 1);
            response.ShouldBeOfType(typeof(MediatR.Unit));
        }
    }
}
