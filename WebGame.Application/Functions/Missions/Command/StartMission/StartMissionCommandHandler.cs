using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Missions.Command.StartMission
{
    public class StartMissionCommandHandler : IRequestHandler<StartMissionCommand, StartMissionCommandResponse>
    {
        private const int NO_MISSION_ID = 0;

        private readonly IPlayerRepository _playerRepository;
        private readonly IMissionRepository _missionRepository;

        public StartMissionCommandHandler(IPlayerRepository playerRepository, IMissionRepository missionRepository)
        {
            _playerRepository = playerRepository;
            _missionRepository = missionRepository;
        }

        public async Task<StartMissionCommandResponse> Handle(StartMissionCommand request, CancellationToken cancellationToken)
        {
            var player = await _playerRepository.GetByIdAsync(request.PlayerId);
            bool hasPlayerMission = player.MissionId != NO_MISSION_ID;

            if (!hasPlayerMission)
            {
                var mission = await _missionRepository.GetByIdAsync(request.MissionId);

                player.MissionId = request.MissionId;
                player.EndMissionTime = DateTime.UtcNow.AddMinutes(mission.Duration);
                await _playerRepository.UpdateAsync(player);

                return new StartMissionCommandResponse(player.EndMissionTime);
            }

            return new StartMissionCommandResponse("Player already has a mission!");
        }
    }
}