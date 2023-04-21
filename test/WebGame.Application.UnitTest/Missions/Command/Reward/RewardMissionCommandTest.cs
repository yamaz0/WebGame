using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using Shouldly;
using System.Threading.Tasks;
using WebGame.Application.Functions.Missions.Command.RewardMission;
using WebGame.Application.Interfaces.TimeAction;
using WebGame.Application.Response;
using WebGame.Application.UnitTest.Mocks.Repository;
using WebGame.TimeAction;

namespace WebGame.Application.UnitTest.Missions.Command.Reward
{
    public class RewardMissionCommandTest
    {
        private const int PLAYER_ID_WITH_DONE_MISSION = 1;
        private const int PLAYER_ID_WITH_MISSION_IN_PROGRESS = 2;
        private const int PLAYER_ID_WITH_NO_ACTION = 3;
        private const int PLAYER_ID_WITH_OTHER_ACTION = 4;

        [Theory]
        [InlineData(PLAYER_ID_WITH_DONE_MISSION)]
        public async void RewardMission_Should_Be_Succesfull(int id)
        {
            var request = new RewardMissionCommand(id);
            var playerRepo = PlayerRepositoryMocks.GetPlayerRepository();
            var missionRepo = MissionRepositoryMocks.GetMissionRepository();
            ITimeActionService timeActionService = new TimeActionService(playerRepo.Object);

            var playerBefore = await playerRepo.Object.GetByIdAsync(id);
            var playerExpBefore = playerBefore.Exp;
            var playerCashBefore = playerBefore.Cash;
            var mission = await missionRepo.Object.GetByIdAsync(playerBefore.ActionId);

            var handler = new RewardMissionCommandHandler(missionRepo.Object, timeActionService, playerRepo.Object);
            var response = await handler.Handle(request, CancellationToken.None);

            var playerAfter = await playerRepo.Object.GetByIdAsync(id);
            response.ShouldBeOfType<BasicResponse>();
            response.Success.ShouldBeTrue();
            playerAfter.Exp.ShouldBe(playerExpBefore + mission.RewardExp);
            playerAfter.Cash.ShouldBe(playerCashBefore + mission.RewardCash);
            playerAfter.ActionId.ShouldBe(0);
        }

        [Theory]
        [InlineData(PLAYER_ID_WITH_NO_ACTION)]
        [InlineData(PLAYER_ID_WITH_MISSION_IN_PROGRESS)]
        [InlineData(PLAYER_ID_WITH_OTHER_ACTION)]
        public async void RewardMission_Should_Be_Failed(int id)
        {
            var request = new RewardMissionCommand(id);
            var playerRepo = PlayerRepositoryMocks.GetPlayerRepository();
            var missionRepo = MissionRepositoryMocks.GetMissionRepository();
            ITimeActionService timeActionService = new TimeActionService(playerRepo.Object);

            var playerBefore = await playerRepo.Object.GetByIdAsync(id);
            var playerMissionIdBefore = playerBefore.ActionId;
            var playerExpBefore = playerBefore.Exp;
            var playerCashBefore = playerBefore.Cash;

            var handler = new RewardMissionCommandHandler(missionRepo.Object, timeActionService, playerRepo.Object);
            var response = await handler.Handle(request, CancellationToken.None);

            var playerAfter = await playerRepo.Object.GetByIdAsync(id);

            response.ShouldBeOfType<BasicResponse>();
            response.Success.ShouldBeFalse();
            playerAfter.ActionId.ShouldBe(playerMissionIdBefore);
            playerAfter.Exp.ShouldBe(playerExpBefore);
            playerAfter.Cash.ShouldBe(playerCashBefore);
        }
    }
}
