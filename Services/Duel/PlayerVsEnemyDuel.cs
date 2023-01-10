using WebGame.Controllers;
using WebGame.Entities.Enemies;
using WebGame.Models;
using WebGame.Services.Duel.Interface;

namespace WebGame.Services.Duel
{
    public class PlayerVsEnemyDuel : IDuel
    {
        public Entities.Player Player { get; set; }
        public Enemy Enemy { get; set; }
        public DuelData Details { get; set; }

        public PlayerVsEnemyDuel(Entities.Player player, Enemy enemy)
        {
            Player = player;
            Enemy = enemy;
            Details = new DuelData();
        }

        public bool Fight()
        {
            DuelCharacter dPlayer = new DuelCharacter();
            dPlayer.Init(Player);

            DuelCharacter dEnemy = new DuelCharacter();
            dEnemy.Init(Enemy);

            for (int i = 0; i < 50; i++)
            {
                int damage = dPlayer.Attack(dEnemy);

                Details.DuelHistory.Add($"{dPlayer.Name} deal {damage} damage to {dEnemy.Name} ");
                if (dEnemy.IsAlive() == false)
                {
                    Details.Result = $"{dPlayer.Name} win!";
                    //Player.Exp += 10;//testowe
                    //Player.Cash += 10;//testowe
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

            Details.Result = $"DRAW";
            return false;
        }
    }
}
