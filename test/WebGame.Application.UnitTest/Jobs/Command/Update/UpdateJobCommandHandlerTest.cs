using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Jobs.Command.Update;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Jobs.Command.Update
{
    public class UpdateJobCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IJobRepository> _mockJobRepository;

        public UpdateJobCommandHandlerTest()
        {
            _mockJobRepository = JobRepositoryMocks.GetJobRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = cfg.CreateMapper();
        }

        [Fact]
        public async void UpdateJobTest()
        {
            var handler = new UpdateJobCommandHandler(_mockJobRepository.Object, _mapper);
            var result = await handler.Handle(new UpdateJobCommand(), CancellationToken.None);

            result.ShouldBeOfType(typeof(MediatR.Unit));
        }
    }
}
