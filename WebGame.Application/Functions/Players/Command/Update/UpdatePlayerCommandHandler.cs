using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Domain.Entities.Player;

namespace WebGame.Application.Functions.Players.Command.Update
{
    public class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public UpdatePlayerCommandHandler(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {
            var mappedPlayer = _mapper.Map<Player>(request);

            await _playerRepository.UpdateAsync(mappedPlayer);

            return Unit.Value;
        }
    }
}
