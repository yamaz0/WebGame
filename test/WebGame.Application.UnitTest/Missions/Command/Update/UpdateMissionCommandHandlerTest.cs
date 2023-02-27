using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Missions.Command.Update;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Missions.Command.Update
{
    public class UpdateMissionCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMissionRepository> _mockMissionRepository;

        public UpdateMissionCommandHandlerTest()
        {
            _mockMissionRepository = MissionRepositoryMocks.GetMissionRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = cfg.CreateMapper();
        }

        [Fact]
        public async void UpdateMissionTest()
        {
            var handler = new UpdateMissionCommandHandler(_mockMissionRepository.Object, _mapper);
            var result = await handler.Handle(new UpdateMissionCommand(), CancellationToken.None);

            result.ShouldBeOfType(typeof(MediatR.Unit));
        }
    }
}
