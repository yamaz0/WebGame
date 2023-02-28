using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Jobs.Command.Create;
using WebGame.Application.Functions.Jobs.Command.Create;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Jobs.Command.Create
{
    public class CreateJobCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IJobRepository> _mockJobRepository;

        public CreateJobCommandHandlerTest()
        {
            _mockJobRepository = JobRepositoryMocks.GetJobRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = cfg.CreateMapper();
        }

        [Fact]
        public async void CreateJobTest()
        {
            var handler = new CreateJobCommandHandler(_mockJobRepository.Object);
            int jobsCountBefore = (await _mockJobRepository.Object.GetAllAsync()).Count;
            CreateJobCommand request = new CreateJobCommand()
            {
                Name = "A",
                Description = "B",
                Duration = 1,
                Reward = 1
            };

            var response = await handler.Handle(request, CancellationToken.None);

            int jobsCountAfter = (await _mockJobRepository.Object.GetAllAsync()).Count;

            jobsCountAfter.ShouldBe(jobsCountBefore + 1);
            response.ShouldBeOfType(typeof(CreateJobCommandResponse));
            response.Success.ShouldBe(true);
            response.Errors.Count.ShouldBe(0);
            response.JobId.ShouldNotBeNull();
        }
    }
}
