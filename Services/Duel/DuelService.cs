using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebGame.Controllers;
using WebGame.Models;
using WebGame.Services.Duel.Interface;

namespace WebGame.Services.Duel
{
    public class DuelService : IDualService
    {
        private readonly DbGameContext _context;

        public DuelService(DbGameContext context)
        {
            _context = context;
        }

        public DuelData Duel(int enemyId)
        {
            var enemy = _context.Enemies.ToList().Find(e => e.Id == enemyId);
            var player = _context.Players
                .Include(p => p.Boots)
                .Include(p => p.Armor)
                .Include(p => p.Helmet)
                .Include(p => p.Legs)
                .Include(p => p.Weapon)
                .ToList().FirstOrDefault();


            //if (player == null) return NotFound();
            //if (enemy == null) return NotFound();

            int duelResult = 0;

            DuelCharacter dPlayer = new DuelCharacter();
            dPlayer.Init(player);


            DuelCharacter dEnemy = new DuelCharacter();
            dEnemy.Init(enemy);

            DuelData dd = new DuelData();

            for (int i = 0; i < 50; i++)
            {
                int damage = dPlayer.Attack(dEnemy);
                dd.DuelHistory.Add($"{dPlayer.Name} deal {damage} to {dEnemy.Name} ");
                if (dEnemy.IsAlive() == false)
                {
                    dd.Result = $"{dPlayer.Name} win!";
                    break;
                }
                damage = dEnemy.Attack(dPlayer);
                dd.DuelHistory.Add($"{dEnemy.Name} deal {damage} to {dPlayer.Name} ");

                if (dPlayer.IsAlive() == false)
                {
                    dd.Result = $"{dPlayer.Name} lose!";
                    break;
                }
            }

            return dd;
        }
    }
}
