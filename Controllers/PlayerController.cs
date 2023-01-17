using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebGame.Entities;
using WebGame.Services.Player.Interface;

namespace WebGame.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly UserManager<UserEntity> _userManager;

        public PlayerController(IPlayerService playerService, UserManager<UserEntity> userManager)
        {
            _playerService = playerService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var player = _playerService.GetPlayer(userId);
            return View(player);
        }
    }
}
