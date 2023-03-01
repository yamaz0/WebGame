using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Domain.Entities.Player;
using WebGame.Entities.Enemies;
using WebGame.Application.Interfaces.Duel;

namespace WebGame.Application.Functions.Duel.Query
{
    public class DuelPlayerVsEnemyQueryHandler : IRequestHandler<DuelPlayerVsEnemyQuery, DuelViewData>
    {
        public readonly IPlayerRepository _playerRepository;
        public readonly IEnemyRepository _enemyRepository;
        public readonly IDuel _duel;

        public DuelPlayerVsEnemyQueryHandler(IPlayerRepository playerRepository, IEnemyRepository enemyRepository, IDuel duel)
        {
            _playerRepository = playerRepository;
            _enemyRepository = enemyRepository;
            _duel = duel;
        }

        public async Task<DuelViewData> Handle(DuelPlayerVsEnemyQuery request, CancellationToken cancellationToken)
        {
            var player = await _playerRepository.GetByIdAsync(request.PlayerId);
            var enemy = await _enemyRepository.GetByIdAsync(request.EnemyId);

            return Duel(player, enemy);
        }

        private DuelViewData Duel(Player player, Enemy enemy)
        {
            DuelData duelData = _duel.StartDuel(player, enemy);

            int rewardCash = 0;
            int rewardExp = 0;

            if (duelData.HasPlayerWon)
            {
                rewardCash = enemy.CashReward;
                rewardExp = enemy.ExpReward;
            }

            return new DuelViewData()
            {
                Player = player,
                PlayerWin = duelData.HasPlayerWon,
                RewardCash = rewardCash,
                RewardExp = rewardExp,
                DuelHistory = duelData.DuelHistory,
                Message = duelData.Message
            };
        }
    }
}
