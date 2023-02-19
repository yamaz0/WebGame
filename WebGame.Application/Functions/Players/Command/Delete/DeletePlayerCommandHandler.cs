using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Players.Command.Delete
{
    public class DeletePlayerCommandHandler : IRequestHandler<DeletePlayerCommand>
    {
        private readonly IPlayerRepository _playerRepository;

        public DeletePlayerCommandHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        public async Task<Unit> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
        {
            var playerToDelete = await _playerRepository.GetByIdAsync(request.PlayerId);
            await _playerRepository.RemoveAsync(playerToDelete);
            return Unit.Value;
        }
    }
}
