using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Players.Query.GetAllPlayers
{
    public class GetAllPlayersRequestHandler : IRequestHandler<GetAllPlayersRequest, List<GetAllPlayersViewModel>>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public GetAllPlayersRequestHandler(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllPlayersViewModel>> Handle(GetAllPlayersRequest request, CancellationToken cancellationToken)
        {
            var players = await _playerRepository.GetAllAsync();
            var playersViewModel = _mapper.Map<List<GetAllPlayersViewModel>>(players);
            return playersViewModel;
        }
    }
}