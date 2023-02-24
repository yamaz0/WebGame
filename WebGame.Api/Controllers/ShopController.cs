using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebGame.Application.Functions.Weapons.Query;
using WebGame.Application.Functions.Weapons.Query.GetAllWeapons;

namespace WebGame.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly IMediator _mediator;

        //private readonly IShopService _shopService;
        //private readonly UserManager<UserEntity> _userManager;

        public ShopController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return NoContent();
        }

        //[HttpGet("armors")]
        //public IActionResult Armors()
        //{
        //    IEnumerable<BodyArmor> armors = _shopService.GetAllBodyArmors();
        //    return View(armors);
        //}

        //[HttpGet("armors/{itemId:int}")]
        //public IActionResult Armors(int itemId)
        //{
        //    var userId = _userManager.GetUserId(HttpContext.User);
        //    _shopService.BuyBodyArmorItem(userId, itemId);
        //    return RedirectToAction("Armors", new { itemId = (int?)null });
        //}

        [HttpGet("weapons")]
        public async Task<ActionResult<List<GetAllWeaponsViewModel>>> Weapons()
        {
            GetAllWeaponsRequest request = new GetAllWeaponsRequest();
            List<GetAllWeaponsViewModel> weapons = await _mediator.Send(request);
            return Ok(weapons);
        }

        ////[HttpPost("weapons")]
        ////    [Authorize(Roles="Administrator")]
        ////public async Task<IActionResult> Weapons()
        ////{
        ////    GetAllWeaponsRequest request = new GetAllWeaponsRequest();
        ////    List<Entities.Items.Weapon> weapons = await _mediator.Send(request);
        ////    return View(weapons);
        //}
        //[HttpGet("weapons/{itemId}")]
        //public IActionResult Weapons(int itemId)
        //{
        //    var userId = _userManager.GetUserId(HttpContext.User);
        //    _shopService.BuyWeaponItem(userId, itemId);
        //    return RedirectToAction("Weapons", new { itemId = (int?)null });
        //}
    }
}
