using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Interfaces.TimeAction;
using WebGame.Application.Response;
using WebGame.Domain.TimeActionEnum;

namespace WebGame.Application.Functions.Missions.Command
{
    public class CheckMissionCommandHandler : IRequestHandler<CheckMissionCommand, Response.TimeActionResponse>
    {
        private readonly ITimeActionService _timeActionService;

        public CheckMissionCommandHandler(ITimeActionService timeActionService)
        {
            _timeActionService = timeActionService;
        }

        public async Task<Response.TimeActionResponse> Handle(CheckMissionCommand request, CancellationToken cancellationToken)
        {
            var timeActionResponse = await _timeActionService.Check(request.PlayerId, TimeActionType.Mission);

            return timeActionResponse;
        }
    }
}
