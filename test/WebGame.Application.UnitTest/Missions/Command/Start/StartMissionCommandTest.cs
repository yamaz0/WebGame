using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Functions.Missions.Command.StartMission;
using WebGame.Application.Interfaces.TimeAction;
using WebGame.Application.Response;
using WebGame.Application.UnitTest.Mocks.Repository;
using WebGame.Domain.TimeActionEnum;
using WebGame.TimeAction;

namespace WebGame.Application.UnitTest.Missions.Command.Start
{
    public class StartMissionCommandTest
    {
        private const int MISSION_ID = 1;
        private const int PLAYER_ID_WITH_DONE_MISSION = 1;
        private const int PLAYER_ID_WITH_MISSION_IN_PROGRESS = 2;
        private const int PLAYER_ID_WITH_NO_ACTION = 3;
        private const int PLAYER_ID_WITH_OTHER_ACTION = 4;

        [Theory]
        [InlineData(PLAYER_ID_WITH_NO_ACTION)]
        public async void StartMission_Should_Be_Succesfull(int id)
        {
            var request = new StartMissionCommand(id, MISSION_ID);
            var playerRepo = PlayerRepositoryMocks.GetPlayerRepository();
            var missionRepo = MissionRepositoryMocks.GetMissionRepository();
            ITimeActionService timeActionService = new TimeActionService(playerRepo.Object);

            var playerBefore = await playerRepo.Object.GetByIdAsync(id);
            var playerMissionIdBefore = playerBefore.ActionId;

            var handler = new StartMissionCommandHandler(missionRepo.Object, timeActionService);
            var response = await handler.Handle(request, CancellationToken.None);

            var playerAfter = await playerRepo.Object.GetByIdAsync(id);

            response.ShouldBeOfType<BasicResponse>();
            response.Success.ShouldBeTrue();
            playerAfter.ActionId.ShouldNotBe(playerMissionIdBefore);
        }

        [Theory]
        [InlineData(PLAYER_ID_WITH_DONE_MISSION)]
        [InlineData(PLAYER_ID_WITH_MISSION_IN_PROGRESS)]
        [InlineData(PLAYER_ID_WITH_OTHER_ACTION)]
        public async void StartMission_Should_Be_Failed(int id)
        {
            var request = new StartMissionCommand(id, MISSION_ID);
            var playerRepo = PlayerRepositoryMocks.GetPlayerRepository();
            var missionRepo = MissionRepositoryMocks.GetMissionRepository();
            ITimeActionService timeActionService = new TimeActionService(playerRepo.Object);

            var playerBefore = await playerRepo.Object.GetByIdAsync(id);
            var playerMissionIdBefore = playerBefore.ActionId;

            var handler = new StartMissionCommandHandler(missionRepo.Object, timeActionService);
            var response = await handler.Handle(request, CancellationToken.None);

            var playerAfter = await playerRepo.Object.GetByIdAsync(id);

            response.ShouldBeOfType<BasicResponse>();
            response.Success.ShouldBeFalse();
            playerAfter.ActionId.ShouldBe(playerMissionIdBefore);
        }
    }
}
