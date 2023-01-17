using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
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
            _shopService.BuyBodyArmorItem(itemId);
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
            _shopService.BuyWeaponItem(itemId);
            return RedirectToAction("Weapons", new { itemId = (int?)null });
        }
    }
}
