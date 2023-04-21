using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebGame.Application.Functions.Shop.Command.BuyArmor;
using WebGame.Api.Common;
using WebGame.Application.Functions.Shop.Command.BuyWeapon;
using Microsoft.AspNetCore.Authorization;

namespace WebGame.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShopController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("shop/armors/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Application.Response.BasicResponse>> BuyArmor(int id)
        {
            var playerId = Utils.GetPlayerId(User);
            var request = new BuyArmorShopCommand(playerId, id);

            var response = await _mediator.Send(request);

            if (response == null)
                return NotFound(response);
            return Ok(response);
        }

        [Authorize]
        [HttpPost("shop/weapons/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Application.Response.BasicResponse>> BuyWeapon(int id)
        {
            var playerId = Utils.GetPlayerId(User);
            var request = new BuyWeaponShopCommand(playerId, id);

            var response = await _mediator.Send(request);

            if (response == null)
                return NotFound(response);
            return Ok(response);
        }
    }
}
