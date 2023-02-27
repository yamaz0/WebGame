using AutoMapper;
using Moq;
using Shouldly;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Enemies.Query.GetAllEnemies;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Enemys.Query.GetAll
{
    public class GetAllEnemysQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IEnemyRepository> _mockEnemyRepository;

        public GetAllEnemysQueryHandlerTest()
        {
            _mockEnemyRepository = EnemyRepositoryMocks.GetEnemyRepository();
            var configureProvider = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = configureProvider.CreateMapper();
        }

        [Fact]
        public async void GetAllEnemysTest()
        {
            var handler = new GetAllEnemiesRequestHandler(_mockEnemyRepository.Object, _mapper);
            var result = await handler.Handle(new GetAllEnemiesRequest(), CancellationToken.None);
            result.ShouldBeOfType<List<GetAllEnemiesViewModel>>();
        }
    }
}