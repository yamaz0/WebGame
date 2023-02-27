using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Jobs.Query;
using WebGame.Application.Functions.Jobs.Query.GetJob;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Jobs.Query.GetOne
{
    public class GetJobQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IJobRepository> _mockJobRepository;

        public GetJobQueryHandlerTest()
        {
            _mockJobRepository = JobRepositoryMocks.GetJobRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            _mapper = new Mapper(cfg);
        }

        [Fact]
        public async void GetJobTest()
        {
            var handler = new GetJobRequestHandler(_mockJobRepository.Object, _mapper);
            var result = await handler.Handle(new GetJobRequest() { JobId = 1 }, CancellationToken.None);
            result.ShouldBeOfType(typeof(GetJobViewModel));
        }
    }
}
