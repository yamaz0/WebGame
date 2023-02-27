using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Automapper;
using WebGame.Application.Functions.Missions.Query;
using WebGame.Application.Functions.Missions.Query.GetMission;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Missions.Query.GetOne
{
    public class GetMissionQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMissionRepository> _mockMissionRepository;

        public GetMissionQueryHandlerTest()
        {
            _mockMissionRepository = MissionRepositoryMocks.GetMissionRepository();
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            _mapper = new Mapper(cfg);
        }

        [Fact]
        public async void GetMissionTest()
        {
            var handler = new GetMissionRequestHandler(_mockMissionRepository.Object, _mapper);
            var result = handler.Handle(new GetMissionRequest(), CancellationToken.None);
            result.ShouldBeOfType(typeof(GetMissionViewModel));
        }
    }
}
