using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Interfaces.TimeAction;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.Missions.Command.StartMission
{
    public class StartMissionCommandHandler : IRequestHandler<StartMissionCommand, BasicResponse>
    {
        private readonly IMissionRepository _missionRepository;
        private readonly ITimeActionService _timeActionService;

        public StartMissionCommandHandler(IMissionRepository missionRepository, ITimeActionService timeActionService)
        {
            _missionRepository = missionRepository;
            _timeActionService = timeActionService;
        }

        public async Task<BasicResponse> Handle(StartMissionCommand request, CancellationToken cancellationToken)
        {
            var mission = await _missionRepository.GetByIdAsync(request.MissionId);

            if (mission == null)
                return new BasicResponse("Mission not found.");

            bool isSuccess = await _timeActionService.SetActionToPlayer(request.PlayerId, Domain.TimeActionEnum.TimeActionType.Mission, mission);

            if (!isSuccess)
            {
                return new BasicResponse("Cant start mission.");
            }

            return new BasicResponse();
        }
    }
}