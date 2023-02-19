using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Players.Query.GetPlayer
{
    public class GetPlayerRequestHandler : IRequestHandler<GetPlayerRequest, GetPlayerViewModel>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public GetPlayerRequestHandler(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<GetPlayerViewModel> Handle(GetPlayerRequest request, CancellationToken cancellationToken)
        {
            var player = await _playerRepository.GetByIdAsync(request.PlayerId);
            var mappedPlayer = _mapper.Map<GetPlayerViewModel>(player);

            return mappedPlayer;
        }
    }
}
