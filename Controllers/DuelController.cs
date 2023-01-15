using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<UserEntity> _userManager;

        public DuelController(IDualService service, UserManager<UserEntity> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        public IActionResult DuelEnemy(int enemyId)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var dueldata = _service.DuelEnemy(userId, enemyId);

            if (dueldata == null)
                return NotFound();
            else
                return View(dueldata);
        }
        public IActionResult DuelPlayer(int enemyId)
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            var dueldata = _service.DuelPlayer(userId, enemyId);

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
