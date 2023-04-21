using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Functions.Missions.Command;
using WebGame.Application.Interfaces.TimeAction;
using WebGame.Application.Response;
using WebGame.Application.UnitTest.Mocks.Repository;
using WebGame.TimeAction;
using Xunit;

namespace WebGame.Application.UnitTest.Missions.Command
{
    public class CheckMissionCommandTest
    {
        private const int PLAYER_ID_WITH_DONE_MISSION = 1;
        private const int PLAYER_ID_WITH_MISSION_IN_PROGRESS = 2;
        private const int PLAYER_ID_WITH_NO_ACTION = 3;
        private const int PLAYER_ID_WITH_OTHER_ACTION = 4;

        [Theory]
        [InlineData(PLAYER_ID_WITH_DONE_MISSION, TimeActionStateResponse.Finished)]
        [InlineData(PLAYER_ID_WITH_MISSION_IN_PROGRESS, TimeActionStateResponse.InProgress)]
        [InlineData(PLAYER_ID_WITH_NO_ACTION, TimeActionStateResponse.NoAction)]
        [InlineData(PLAYER_ID_WITH_OTHER_ACTION, TimeActionStateResponse.OtherAction)]
        public async void CheckMission_Should_Not_Modify_Player_And_Return_Correct_Response(int id, TimeActionStateResponse expectedState)
        {
            var request = new CheckMissionCommand(id);
            var playerRepo = PlayerRepositoryMocks.GetPlayerRepository();
            ITimeActionService timeActionService = new TimeActionService(playerRepo.Object);

            var playerBefore = await playerRepo.Object.GetByIdAsync(id);
            var playerExpBefore = playerBefore.Exp;
            var playerCashBefore = playerBefore.Cash;

            var handler = new CheckMissionCommandHandler(timeActionService);
            var response = await handler.Handle(request, CancellationToken.None);

            var playerAfter = await playerRepo.Object.GetByIdAsync(id);

            response.ShouldBeOfType<TimeActionResponse>();
            response.TimeActionStateResponse.ShouldBe(expectedState);
            playerAfter.Exp.ShouldBe(playerExpBefore);
            playerAfter.Cash.ShouldBe(playerCashBefore);
        }
    }
}