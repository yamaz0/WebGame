using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Domain.Entities.Player;

namespace WebGame.Application.Functions.Players.Command.AddedStats
{
    public class AddedStatsPlayerCommandHandler : IRequestHandler<AddedStatsPlayerCommand>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public AddedStatsPlayerCommandHandler(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddedStatsPlayerCommand request, CancellationToken cancellationToken)
        {
            var player = await _playerRepository.GetByIdAsync(request.PlayerId);
            if (player.SkillPoints < 0)
            {
                switch (request.Statistic)
                {
                    case Domain.PlayerStatsEnum.Statistic.Strenght:
                        player.AddStrenght();
                        break;
                    case Domain.PlayerStatsEnum.Statistic.Dexterity:
                        player.AddDexterity();
                        break;
                    case Domain.PlayerStatsEnum.Statistic.Endurance:
                        player.AddEndurance();
                        break;
                    default:
                        break;
                }
            }

            await _playerRepository.UpdateAsync(player);

            return Unit.Value;
        }
    }
}
