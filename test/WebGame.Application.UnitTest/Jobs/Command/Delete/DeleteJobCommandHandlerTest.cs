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
            var result = await handler.Handle(new DeleteJobCommand(), CancellationToken.None);

            result.ShouldBeOfType(typeof(MediatR.Unit));
        }
    }
}
