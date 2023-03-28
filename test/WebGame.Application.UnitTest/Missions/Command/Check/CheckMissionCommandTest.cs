using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Functions.Missions.Command;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Missions.Command
{
    public class CheckMissionCommandTest
    {
        private const int PLAYER_ID_WITH_DONE_MISSION = 1;
        private const int PLAYER_ID_WITH_MISSION_IN_PROGRESS = 2;
        private const int PLAYER_ID_WITH_NO_MISSION = 3;

        [Fact]
        public async void CheckMission_Should_Be_Succesfull()
        {
            var request = new CheckMissionCommand(PLAYER_ID_WITH_DONE_MISSION);
            var playerRepo = PlayerRepositoryMocks.GetPlayerRepository();
            var missionRepo = MissionRepositoryMocks.GetMissionRepository();

            var playerBefore = await playerRepo.Object.GetByIdAsync(PLAYER_ID_WITH_DONE_MISSION);
            var playerExpBefore = playerBefore.Exp;
            var mission = await missionRepo.Object.GetByIdAsync(playerBefore.MissionId);

            var handler = new CheckMissionCommandHandler(playerRepo.Object, missionRepo.Object);
            var response = await handler.Handle(request, CancellationToken.None);

            var playerAfter = await playerRepo.Object.GetByIdAsync(PLAYER_ID_WITH_DONE_MISSION);

            response.ShouldBeOfType<CheckMissionCommandResponse>();
            response.HasPlayerMission.ShouldBeTrue();
            response.IsMissionFinished.ShouldBeTrue();
            playerAfter.Exp.ShouldBe(playerExpBefore + mission.Reward);
        }

        [Fact]
        public async void CheckMission_Should_Be_InProgress()
        {
            var request = new CheckMissionCommand(PLAYER_ID_WITH_MISSION_IN_PROGRESS);
            var playerRepo = PlayerRepositoryMocks.GetPlayerRepository();
            var missionRepo = MissionRepositoryMocks.GetMissionRepository();

            var playerBefore = await playerRepo.Object.GetByIdAsync(PLAYER_ID_WITH_DONE_MISSION);
            var playerExpBefore = playerBefore.Exp;

            var handler = new CheckMissionCommandHandler(playerRepo.Object, missionRepo.Object);
            var response = await handler.Handle(request, CancellationToken.None);

            var playerAfter = await playerRepo.Object.GetByIdAsync(PLAYER_ID_WITH_DONE_MISSION);

            response.ShouldBeOfType<CheckMissionCommandResponse>();
            response.HasPlayerMission.ShouldBeTrue();
            response.IsMissionFinished.ShouldBeFalse();
            playerAfter.Exp.ShouldBe(playerExpBefore);
        }

        [Fact]
        public async void CheckMission_Should_Be_NoMission()
        {
            var request = new CheckMissionCommand(PLAYER_ID_WITH_NO_MISSION);
            var playerRepo = PlayerRepositoryMocks.GetPlayerRepository();
            var missionRepo = MissionRepositoryMocks.GetMissionRepository();

            var playerBefore = await playerRepo.Object.GetByIdAsync(PLAYER_ID_WITH_DONE_MISSION);
            var playerExpBefore = playerBefore.Exp;

            var handler = new CheckMissionCommandHandler(playerRepo.Object, missionRepo.Object);
            var response = await handler.Handle(request, CancellationToken.None);

            var playerAfter = await playerRepo.Object.GetByIdAsync(PLAYER_ID_WITH_DONE_MISSION);

            response.ShouldBeOfType<CheckMissionCommandResponse>();
            response.HasPlayerMission.ShouldBeFalse();
            playerAfter.Exp.ShouldBe(playerExpBefore);
        }
    }
}
