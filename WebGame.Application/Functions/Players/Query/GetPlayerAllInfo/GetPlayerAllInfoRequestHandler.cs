using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Players.Query.GetPlayer
{
    public class GetPlayerAllInfoRequestHandler : IRequestHandler<GetPlayerAllInfoRequest, GetPlayerAllInfoViewModel>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public GetPlayerAllInfoRequestHandler(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<GetPlayerAllInfoViewModel> Handle(GetPlayerAllInfoRequest request, CancellationToken cancellationToken)
        {
            var player = await _playerRepository.GetByIdAsync(request.PlayerId);
            var mappedPlayer = _mapper.Map<GetPlayerAllInfoViewModel>(player);

            return mappedPlayer;
        }
    }
}
