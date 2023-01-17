using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGame.Services.Player.Interface;

namespace WebGame.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        public IActionResult Index()
        {
            var player = _playerService.GetPlayer();
            return View(player);
        }
    }
}
