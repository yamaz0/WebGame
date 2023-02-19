using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Domain.Entities.Player;
using WebGame.Entities.Enemies;

namespace WebGame.Application.Functions.Duel.Query
{
    public class DuelPlayerVsEnemyQueryHandler : IRequestHandler<DuelPlayerVsEnemyQuery, DuelViewData>
    {
        public readonly IPlayerRepository _playerRepository;
        public readonly IEnemyRepository _enemyRepository;

        public DuelPlayerVsEnemyQueryHandler(IPlayerRepository playerRepository, IEnemyRepository enemyRepository)
        {
            _playerRepository = playerRepository;
            _enemyRepository = enemyRepository;
        }

        public async Task<DuelViewData> Handle(DuelPlayerVsEnemyQuery request, CancellationToken cancellationToken)
        {
            var player = await _playerRepository.GetByIdAsync(request.PlayerId);
            var enemy = await _enemyRepository.GetByIdAsync(request.EnemyId);

            return Duel(player, enemy);
        }

        private DuelViewData Duel(Player player, Enemy enemy)
        {
            Duelist dPlayer = new Duelist(player);
            Duelist dEnemy = new Duelist(enemy);

            List<string> duelHistory = new List<string>();
            string message = "Draw!";
            bool isPlayerWon = false;
            int rewardCash = enemy.CashReward;
            int rewardExp = enemy.ExpReward;

            for (int i = 0; i < 50; i++)
            {
                int damage = dPlayer.AttackOpponent(dEnemy);
                duelHistory.Add($"{player.Name} deal {damage} damage to {enemy.Name} ");
                if (dEnemy.IsAlive() == false)
                {
                    message = $"{player.Name} win!";
                    isPlayerWon = true;
                    break;
                }

                damage = dEnemy.AttackOpponent(dPlayer);
                duelHistory.Add($"{enemy.Name} deal {damage} damage to {player.Name} ");
                if (dPlayer.IsAlive() == false)
                {
                    message = $"{player.Name} lose!";
                    break;
                }
            }

            return new DuelViewData()
            {
                Player = player,
                PlayerWin = isPlayerWon,
                RewardCash = rewardCash,
                RewardExp = rewardExp,
                DuelHistory = duelHistory,
                Message = message
            };
        }
    }
}
