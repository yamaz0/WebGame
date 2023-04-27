using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Interfaces.TimeAction;
using WebGame.Application.Response;
using WebGame.Domain.Common;

namespace WebGame.Application.Functions.Jobs.Command.StartJob
{
    public class StartJobCommandHandler : IRequestHandler<StartJobCommand, BasicResponse>
    {
        private const int NO_ID = 0;
        private readonly ITimeActionService _timeActionService;

        public StartJobCommandHandler(ITimeActionService timeActionService)
        {
            _timeActionService = timeActionService;
        }

        public async Task<BasicResponse> Handle(StartJobCommand request, CancellationToken cancellationToken)
        {
            bool isSuccess = await _timeActionService.SetActionToPlayer(request.PlayerId, Domain.TimeActionEnum.TimeActionType.Work, NO_ID, request.Duration);

            if (!isSuccess)
            {
                return new BasicResponse("Cant start job.");
            }

            return new BasicResponse();
        }
    }
}