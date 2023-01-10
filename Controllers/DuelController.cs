using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebGame.Entities;
using WebGame.Entities.Enemies;
using WebGame.Services.Duel.Interface;

namespace WebGame.Controllers
{
    public class DuelController : Controller
    {
        private readonly IDualService _service;

        public DuelController(IDualService service)
        {
            _service = service;
        }

        public IActionResult DuelEnemy(int enemyId)
        {
            var dueldata = _service.DuelEnemy(enemyId);

            if (dueldata == null)
                return NotFound();
            else
                return View(dueldata);
        }
        public IActionResult DuelPlayer(int enemyId)
        {
            var dueldata = _service.DuelPlayer(enemyId);

            if (dueldata == null)
                return NotFound();
            else
                return View(dueldata);
        }
    }
    public class DuelCharacter
    {
        public string Name { get; set; }
        public int HealthPoint { get; set; }
        public int AttackPoint { get; set; }

        public void Init(Player player)
        {
            Name = player.Name;
            HealthPoint = player.Endurance * 10;
            AttackPoint = player.Weapon == null ? 1 : player.Weapon.Attack;
        }

        public void Init(Enemy enemy)
        {
            Name = enemy.Name;
            HealthPoint = enemy.HealthPoint;
            AttackPoint = enemy.Attack;
        }

        public int Attack(DuelCharacter opponent)
        {
            opponent.TakeDamage(AttackPoint);
            return AttackPoint;
        }

        public void TakeDamage(int value)
        {
            HealthPoint -= value;
        }

        public bool IsAlive()
        {
            return HealthPoint > 0;
        }
    }
}
