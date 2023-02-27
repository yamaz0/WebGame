using AutoMapper;
using Moq;
using Shouldly;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Players.Query.GetAllPlayers;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Players.Query.GetAll
{
    public class GetAllPlayersQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPlayerRepository> _mockPlayerRepository;

        public GetAllPlayersQueryHandlerTest()
        {
            _mockPlayerRepository = PlayerRepositoryMocks.GetPlayerRepository();
            var configureProvider = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = configureProvider.CreateMapper();
        }

        [Fact]
        public async void GetAllPlayersTest()
        {
            var handler = new GetAllPlayersRequestHandler(_mockPlayerRepository.Object, _mapper);
            var result = await handler.Handle(new GetAllPlayersRequest(), CancellationToken.None);
            result.ShouldBeOfType<List<GetAllPlayersViewModel>>();
        }
    }
}