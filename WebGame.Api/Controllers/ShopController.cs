using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebGame.Application.Functions.Armors.Query.GetAllArmors;
using WebGame.Application.Functions.Weapons.Query;
using WebGame.Application.Functions.Weapons.Query.GetAllWeapons;

namespace WebGame.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShopController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return NoContent();
        }

        [HttpGet("armors")]
        public async Task<ActionResult<List<GetAllArmorsViewModel>>> Armors()
        {
            GetAllArmorsRequest request = new GetAllArmorsRequest();
            List<GetAllArmorsViewModel> armors = await _mediator.Send(request);
            return Ok(armors);
        }

        [HttpGet("weapons")]
        public async Task<ActionResult<List<GetAllWeaponsViewModel>>> Weapons()
        {
            GetAllWeaponsRequest request = new GetAllWeaponsRequest();
            List<GetAllWeaponsViewModel> weapons = await _mediator.Send(request);
            return Ok(weapons);
        }
    }
}