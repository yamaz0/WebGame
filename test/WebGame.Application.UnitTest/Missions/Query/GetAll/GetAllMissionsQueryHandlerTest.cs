using AutoMapper;
using Moq;
using Shouldly;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Missions.Query.GetAllMissions;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Missions.Query.GetAll
{
    public class GetAllMissionsQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMissionRepository> _mockMissionRepository;

        public GetAllMissionsQueryHandlerTest()
        {
            _mockMissionRepository = MissionRepositoryMocks.GetMissionRepository();
            var configureProvider = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = configureProvider.CreateMapper();
        }

        [Fact]
        public async void GetAllMissionsTest()
        {
            var handler = new GetAllMissionsRequestHandler(_mockMissionRepository.Object, _mapper);
            var result = await handler.Handle(new GetAllMissionsRequest(), CancellationToken.None);
            result.ShouldBeOfType<List<GetAllMissionsViewModel>>();
        }
    }
}