using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGame.Entities.Items;
using WebGame.Services.Shop;
using WebGame.Services.Shop.Interfaces;

namespace WebGame.Controllers
{
    //[Authorize]
    [Route("shop")]
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        public IActionResult Index()
        {
            IEnumerable<BodyArmor> armors = _shopService.GetAllBodyArmors();
            return View(armors);
        }
        [HttpGet("armors")]
        public IActionResult Armors()
        {
            IEnumerable<BodyArmor> armors = _shopService.GetAllBodyArmors();
            return View(armors);
        }
        [HttpGet("weapons")]
        public IActionResult Weapons()
        {
            IEnumerable<BodyArmor> armors = _shopService.GetAllBodyArmors();
            return View(armors);
        }
    }
}
