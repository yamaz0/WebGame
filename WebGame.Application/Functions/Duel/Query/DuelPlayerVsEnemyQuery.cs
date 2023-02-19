using MediatR;
using Microsoft.Identity.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Response;
using WebGame.Controllers;
using WebGame.Domain.Common;
using WebGame.Domain.Entities.Player;
using WebGame.Entities.Enemies;

namespace WebGame.Application.Functions.Duel.Query
{
    public class DuelPlayerVsEnemyQuery : IRequest<DuelViewData>
    {
        public int PlayerId { get; set; }
        public int EnemyId { get; set; }
    }
    public class DuelPlayerVsEnemyQueryHandler : IRequestHandler<DuelPlayerVsEnemyQuery, DuelViewData>
    {
        public readonly IPlayerRepository _playerRepository;
        public readonly IEnemyRepository _enemyRepository;

        public DuelPlayerVsEnemyQueryHandler(IPlayerRepository playerRepository, IEnemyRepository enemyRepository)
        {
            _playerRepository = playerRepository;
            _enemyRepository = enemyRepository;
        }

        public class Duelist
        {
            public int HealthPoint { get; set; }
            public int Defense { get; set; }
            public int AttackPoint { get; set; }
            public int AttackSpeed { get; set; }

            public Duelist(IDuelable duelableEntity)
            {
                HealthPoint = duelableEntity.HealthPoint;
                Defense = duelableEntity.Defense;
                AttackPoint = duelableEntity.Attack;
                AttackSpeed = duelableEntity.AttackSpeed;
            }

            public int Attack(Duelist opponent)
            {
                return opponent.TakeDamage(AttackPoint);
            }

            public int TakeDamage(int value)
            {
                int damage = value - Defense;
                HealthPoint -= damage;
                return damage;
            }

            public bool IsAlive()
            {
                return HealthPoint > 0;
            }
        }

        public async Task<DuelViewData> Handle(DuelPlayerVsEnemyQuery request, CancellationToken cancellationToken)
        {
            var player = await _playerRepository.GetByIdAsync(request.PlayerId);
            var enemy = await _enemyRepository.GetByIdAsync(request.EnemyId);

            Duelist dPlayer = new Duelist(player);
            Duelist dEnemy = new Duelist(enemy);

            List<string> duelHistory = new List<string>();
            bool isPlayerWon = false;
            int rewardCash = 0;
            int rewardExp = 0;

            for (int i = 0; i < 50; i++)
            {
                int damage = dPlayer.Attack(dEnemy);

                Details.DuelHistory.Add($"{dPlayer.Name} deal {damage} damage to {dEnemy.Name} ");
                if (dEnemy.IsAlive() == false)
                {
                    Details.Result = $"{dPlayer.Name} win!";
                    return true;
                }
                damage = dEnemy.Attack(dPlayer);
                Details.DuelHistory.Add($"{dEnemy.Name} deal {damage} damage to {dPlayer.Name} ");

                if (dPlayer.IsAlive() == false)
                {
                    Details.Result = $"{dPlayer.Name} lose!";
                    return false;
                }
            }

            return new DuelViewData()
            {
                PlayerWin = isPlayerWon,
                RewardCash = rewardCash,
                RewardExp = rewardExp,
                DuelHistory = duelHistory
            };
        }
    }

    public class DuelViewData
    {
        public bool PlayerWin { get; set; }
        public List<string> DuelHistory { get; set; }
        public int RewardCash { get; set; }
        public int RewardExp { get; set; }
        //jakies dodatkowe rzeczy dodac
    }
}
