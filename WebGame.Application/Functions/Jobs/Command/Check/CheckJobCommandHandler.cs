using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Interfaces.TimeAction;
using WebGame.Application.Response;
using WebGame.Domain.TimeActionEnum;

namespace WebGame.Application.Functions.Jobs.Command
{
    public class CheckJobCommandHandler : IRequestHandler<CheckJobCommand, Response.TimeActionResponse>
    {
        private readonly ITimeActionService _timeActionService;

        public CheckJobCommandHandler(ITimeActionService timeActionService)
        {
            _timeActionService = timeActionService;
        }

        public async Task<Response.TimeActionResponse> Handle(CheckJobCommand request, CancellationToken cancellationToken)
        {
            var timeActionResponse = await _timeActionService.Check(request.PlayerId, TimeActionType.Work);

            return timeActionResponse;
        }
    }
}
