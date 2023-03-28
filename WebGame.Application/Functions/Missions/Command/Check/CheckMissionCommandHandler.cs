using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Missions.Command
{
    public class CheckMissionCommandHandler : IRequestHandler<CheckMissionCommand, CheckMissionCommandResponse>
    {
        private const int NO_MISSION_ID = 0;

        private readonly IPlayerRepository _playerRepository;
        private readonly IMissionRepository _missionRepository;

        public CheckMissionCommandHandler(IPlayerRepository playerRepository, IMissionRepository missionRepository)
        {
            _playerRepository = playerRepository;
            _missionRepository = missionRepository;
        }

        public async Task<CheckMissionCommandResponse> Handle(CheckMissionCommand request, CancellationToken cancellationToken)
        {
            var player = await _playerRepository.GetByIdAsync(request.PlayerId);
            bool hasPlayerMission = player.MissionId != NO_MISSION_ID;
            bool isMissionFinished = false;

            if (hasPlayerMission)
            {
                isMissionFinished = player.EndMissionTime < DateTime.UtcNow;

                if (isMissionFinished)
                {
                    var mission = await _missionRepository.GetByIdAsync(player.MissionId);

                    player.Exp += mission.Reward;
                    player.MissionId = NO_MISSION_ID;
                }
            }

            return new CheckMissionCommandResponse()
            {
                HasPlayerMission = hasPlayerMission,
                IsMissionFinished = isMissionFinished,
                MissionEndTime = player.EndMissionTime
            };
        }
    }
}
