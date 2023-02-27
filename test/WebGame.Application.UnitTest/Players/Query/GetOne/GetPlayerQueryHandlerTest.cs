using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Players.Query;
using WebGame.Application.Functions.Players.Query.GetPlayer;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Players.Query.GetOne
{
    public class GetPlayerQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPlayerRepository> _mockPlayerRepository;

        public GetPlayerQueryHandlerTest()
        {
            _mockPlayerRepository = PlayerRepositoryMocks.GetPlayerRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            _mapper = new Mapper(cfg);
        }

        [Fact]
        public async void GetPlayerTest()
        {
            var handler = new GetPlayerRequestHandler(_mockPlayerRepository.Object, _mapper);
            var result = await handler.Handle(new GetPlayerRequest() { PlayerId = 1 }, CancellationToken.None);
            result.ShouldBeOfType(typeof(GetPlayerViewModel));
        }
    }
}
