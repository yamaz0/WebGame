using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Interfaces.TimeAction;
using WebGame.Application.Response;
using WebGame.Domain.TimeActionEnum;

namespace WebGame.Application.Functions.Jobs.Command.RewardJob
{
    public class RewardJobCommandHandler : IRequestHandler<RewardJobCommand, BasicResponse>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ITimeActionService _timeActionService;

        public RewardJobCommandHandler(ITimeActionService timeActionService, IPlayerRepository playerRepository)
        {
            _timeActionService = timeActionService;
            _playerRepository = playerRepository;
        }

        public async Task<BasicResponse> Handle(RewardJobCommand request, CancellationToken cancellationToken)
        {
            var player = await _playerRepository.GetByIdAsync(request.PlayerId);

            bool isSuccess = await _timeActionService.RewardPlayer(player, TimeActionType.Work, 0, 0);//TODO obliczenie rewardu na podstawie przechowanego duration czy cos

            if (!isSuccess)
            {
                return new BasicResponse("Cant reward player.");
            }

            return new BasicResponse();
        }
    }
}