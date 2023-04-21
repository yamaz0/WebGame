using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Domain.Entities.Player;
using WebGame.Entities.Enemies;
using WebGame.Application.Interfaces.Duel;

namespace WebGame.Application.Functions.Duel.Command
{
    public class DuelPlayerVsEnemyCommandHandler : IRequestHandler<DuelPlayerVsEnemyCommand, DuelPlayerVsEnemyResponse>
    {
        public readonly IPlayerRepository _playerRepository;
        public readonly IEnemyRepository _enemyRepository;
        public readonly IDuel _duel;

        public DuelPlayerVsEnemyCommandHandler(IPlayerRepository playerRepository, IEnemyRepository enemyRepository, IDuel duel)
        {
            _playerRepository = playerRepository;
            _enemyRepository = enemyRepository;
            _duel = duel;
        }

        public async Task<DuelPlayerVsEnemyResponse> Handle(DuelPlayerVsEnemyCommand request, CancellationToken cancellationToken)
        {
            var player = await _playerRepository.GetByIdAsync(request.PlayerId);
            var enemy = await _enemyRepository.GetByIdAsync(request.EnemyId);

            return await Duel(player, enemy);
        }

        private async Task<DuelPlayerVsEnemyResponse> Duel(Player player, Enemy enemy)
        {
            DuelData duelData = await _duel.StartDuel(player, enemy);

            int rewardCash = 0;
            int rewardExp = 0;

            if (duelData.HasPlayerWon)
            {
                rewardCash = enemy.CashReward;
                rewardExp = enemy.ExpReward;
            }

            player.AddReward(rewardExp, rewardCash);

            await _playerRepository.UpdateAsync(player);

            var duelViewData = new DuelViewData()
            {
                Player = player,
                PlayerWin = duelData.HasPlayerWon,
                RewardCash = rewardCash,
                RewardExp = rewardExp,
                DuelHistory = duelData.DuelHistory,
                Message = duelData.Message
            };

            return new DuelPlayerVsEnemyResponse(duelViewData);
        }
    }
}