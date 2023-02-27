using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Missions.Command.Create;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Missions.Command.Create
{
    public class CreateMissionCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMissionRepository> _mockMissionRepository;

        public CreateMissionCommandHandlerTest()
        {
            _mockMissionRepository = MissionRepositoryMocks.GetMissionRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = cfg.CreateMapper();
        }

        [Fact]
        public async void CreateMissionTest()
        {
            var handler = new CreateMissionCommandHandler(_mockMissionRepository.Object);
            var result = await handler.Handle(new CreateMissionCommand(), CancellationToken.None);

            result.ShouldBeOfType(typeof(CreateMissionCommandResponse));
        }
    }
}
