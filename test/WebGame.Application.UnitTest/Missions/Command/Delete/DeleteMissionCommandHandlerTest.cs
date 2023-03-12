using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Missions.Command.Delete;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Missions.Command.Delete
{
    public class DeleteMissionCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMissionRepository> _mockMissionRepository;

        public DeleteMissionCommandHandlerTest()
        {
            _mockMissionRepository = MissionRepositoryMocks.GetMissionRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = cfg.CreateMapper();
        }

        [Fact]
        public async void DeleteMissionTest()
        {            
            var handler = new DeleteMissionCommandHandler(_mockMissionRepository.Object);
            int missionsCountBefore = (await _mockMissionRepository.Object.GetAllAsync()).Count;
            var request = new DeleteMissionCommand(1);

            var response = await handler.Handle(request, CancellationToken.None);

            int missionsCountAfter = (await _mockMissionRepository.Object.GetAllAsync()).Count;

            missionsCountAfter.ShouldBe(missionsCountBefore - 1);
            response.ShouldBeOfType(typeof(MediatR.Unit));
        }
    }
}
