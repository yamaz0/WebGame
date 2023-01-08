using Microsoft.AspNetCore.Mvc;
using WebGame.Services.Arena;
using WebGame.Services.Arena.Interface;

namespace WebGame.Controllers
{
    public class ArenaController : Controller
    {
        private readonly IArenaService _arenaService;

        public ArenaController(IArenaService arenaService)
        {
            _arenaService = arenaService;
        }
        public IActionResult Index()
        {
            var enemies = _arenaService.GetAllEnemies();
            return View(enemies);
        }
    }
}
