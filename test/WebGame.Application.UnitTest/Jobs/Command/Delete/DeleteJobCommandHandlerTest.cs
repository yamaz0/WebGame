using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Jobs.Command.Delete;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Jobs.Command.Delete
{
    public class DeleteJobCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IJobRepository> _mockJobRepository;

        public DeleteJobCommandHandlerTest()
        {
            _mockJobRepository = JobRepositoryMocks.GetJobRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = cfg.CreateMapper();
        }

        [Fact]
        public async void DeleteJobTest()
        {
            var handler = new DeleteJobCommandHandler(_mockJobRepository.Object);
            int jobsCountBefore = (await _mockJobRepository.Object.GetAllAsync()).Count;
            var request = new DeleteJobCommand()
            {
                JobId = 1
            };

            var response = await handler.Handle(request, CancellationToken.None);

            int jobsCountAfter = (await _mockJobRepository.Object.GetAllAsync()).Count;

            jobsCountAfter.ShouldBe(jobsCountBefore - 1);
            response.ShouldBeOfType(typeof(MediatR.Unit));
        }
    }
}
