using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebGame.Entities;
using WebGame.Entities.Items;
using WebGame.Services.Player.Interface;
using WebGame.Services.Shop;
using WebGame.Services.Shop.Interfaces;

namespace WebGame.Controllers
{
    [Authorize]
    [Route("shop")]
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;
        private readonly UserManager<UserEntity> _userManager;

        public ShopController(IShopService shopService, UserManager<UserEntity> userManager)
        {
            _shopService = shopService;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("armors")]
        public IActionResult Armors()
        {
            IEnumerable<BodyArmor> armors = _shopService.GetAllBodyArmors();
            return View(armors);
        }

        [HttpGet("armors/{itemId:int}")]
        public IActionResult Armors(int itemId)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            _shopService.BuyBodyArmorItem(userId, itemId);
            return RedirectToAction("Armors", new { itemId = (int?)null });
        }

        [HttpGet("weapons")]
        public IActionResult Weapons()
        {
            IEnumerable<Weapon> weapons = _shopService.GetAllWeapons();
            return View(weapons);
        }
        [HttpGet("weapons/{itemId}")]
        public IActionResult Weapons(int itemId)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            _shopService.BuyWeaponItem(userId, itemId);
            return RedirectToAction("Weapons", new { itemId = (int?)null });
        }
    }
}
