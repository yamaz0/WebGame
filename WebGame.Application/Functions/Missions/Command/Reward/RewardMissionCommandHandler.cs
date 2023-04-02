using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Interfaces.TimeAction;
using WebGame.Application.Response;
using WebGame.Domain.TimeActionEnum;

namespace WebGame.Application.Functions.Missions.Command.RewardMission
{
    public class RewardMissionCommandHandler : IRequestHandler<RewardMissionCommand, BasicResponse>
    {
        private readonly IMissionRepository _missionRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly ITimeActionService _timeActionService;

        public RewardMissionCommandHandler(IMissionRepository missionRepository, ITimeActionService timeActionService, IPlayerRepository playerRepository)
        {
            _missionRepository = missionRepository;
            _timeActionService = timeActionService;
            _playerRepository = playerRepository;
        }

        public async Task<BasicResponse> Handle(RewardMissionCommand request, CancellationToken cancellationToken)
        {
            var player = await _playerRepository.GetByIdAsync(request.PlayerId);

            var mission = await _missionRepository.GetByIdAsync(player.ActionId);

            if (mission == null)
                return new BasicResponse("Mission not found.");

            bool isSuccess = await _timeActionService.RewardPlayer(player, mission, TimeActionType.Mission);

            if (!isSuccess)
            {
                return new BasicResponse("Cant reward player.");
            }

            return new BasicResponse();
        }
    }
}