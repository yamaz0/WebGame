using AutoMapper;
using Moq;
using Shouldly;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Jobs.Query.GetAllJobs;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Jobs.Query.GetAll
{
    public class GetAllJobsQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IJobRepository> _mockJobRepository;

        public GetAllJobsQueryHandlerTest()
        {
            _mockJobRepository = JobRepositoryMocks.GetJobRepository();
            var configureProvider = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = configureProvider.CreateMapper();
        }

        [Fact]
        public async void GetAllJobsTest()
        {
            var handler = new GetAllJobsRequestHandler(_mockJobRepository.Object, _mapper);
            var result = await handler.Handle(new GetAllJobsRequest(), CancellationToken.None);
            result.ShouldBeOfType<List<GetAllJobsViewModel>>();
        }
    }
}