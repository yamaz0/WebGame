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
            int missionsCountBefore = (await _mockMissionRepository.Object.GetAllAsync()).Count;
            CreateMissionCommand request = new CreateMissionCommand()
            {
                Name = "A",
                Description = "B",
                Reward = 1,
                Duration = 1
            };

            var response = await handler.Handle(request, CancellationToken.None);

            int missionsCountAfter = (await _mockMissionRepository.Object.GetAllAsync()).Count;

            missionsCountAfter.ShouldBe(missionsCountBefore + 1);
            response.ShouldBeOfType(typeof(CreateMissionCommandResponse));
            response.Success.ShouldBe(true);
            response.Errors.Count.ShouldBe(0);
            response.MissionId.ShouldNotBeNull();
        }
    }
}
