using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Functions.Missions.Command.StartMission;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Missions.Command.Start
{
    public class StartMissionCommandTest
    {
        private const int PLAYER_ID_WITH_DONE_MISSION = 1;
        private const int PLAYER_ID_WITH_NO_MISSION = 3;
        private const int MISSION_ID = 1;


        [Fact]
        public async void StartMission_Should_Be_InProgress()
        {
            var request = new StartMissionCommand(PLAYER_ID_WITH_DONE_MISSION, It.IsAny<int>());
            var playerRepo = PlayerRepositoryMocks.GetPlayerRepository();
            var missionRepo = MissionRepositoryMocks.GetMissionRepository();

            var playerBefore = await playerRepo.Object.GetByIdAsync(PLAYER_ID_WITH_DONE_MISSION);
            var playerMissionIdBefore = playerBefore.MissionId;

            var handler = new StartMissionCommandHandler(playerRepo.Object, missionRepo.Object);
            var response = await handler.Handle(request, CancellationToken.None);

            var playerAfter = await playerRepo.Object.GetByIdAsync(PLAYER_ID_WITH_DONE_MISSION);

            response.ShouldBeOfType<StartMissionCommandResponse>();
            playerAfter.MissionId.ShouldBe(playerMissionIdBefore);
        }

        [Fact]
        public async void StartMission_Should_Be_NoMission()
        {
            var request = new StartMissionCommand(PLAYER_ID_WITH_NO_MISSION, MISSION_ID);
            var playerRepo = PlayerRepositoryMocks.GetPlayerRepository();
            var missionRepo = MissionRepositoryMocks.GetMissionRepository();

            var handler = new StartMissionCommandHandler(playerRepo.Object, missionRepo.Object);
            var response = await handler.Handle(request, CancellationToken.None);

            var playerAfter = await playerRepo.Object.GetByIdAsync(PLAYER_ID_WITH_NO_MISSION);

            response.ShouldBeOfType<StartMissionCommandResponse>();
            response.EndTime.ShouldNotBeNull();
            playerAfter.MissionId.ShouldBe(MISSION_ID);
        }
    }
}
