using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebGame.Application.Constants;
using WebGame.Application.Functions.Weapons.Query;
using WebGame.Application.Functions.Weapons.Query.GetAllWeapons;
using WebGame.Application.Functions.Weapons.Query.GetWeapon;

namespace WebGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeaponController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeaponController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("weapons")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<ActionResult<List<GetAllWeaponsViewModel>>> Weapons()
        {
            GetAllWeaponsRequest request = new GetAllWeaponsRequest();
            List<GetAllWeaponsViewModel> weapons = await _mediator.Send(request);
            return Ok(weapons);
        }

        [HttpGet("weapons/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetWeaponViewModel>>> Weapons(int id)
        {
            GetWeaponRequest request = new GetWeaponRequest(id);
            GetWeaponViewModel weapon = await _mediator.Send(request);

            if (weapon == null)
                return NotFound();
            return Ok(weapon);
        }

        #region testowe
        [HttpGet("weaponsAdmin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = ConstantsAuthorization.Roles.ADMINISTRATOR)]
        public async Task<ActionResult<List<GetAllWeaponsViewModel>>> WeaponsAdmin()
        {
            GetAllWeaponsRequest request = new GetAllWeaponsRequest();
            List<GetAllWeaponsViewModel> weapons = await _mediator.Send(request);
            return Ok(weapons);
        }

        [HttpGet("weaponsAuth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<ActionResult<List<GetAllWeaponsViewModel>>> WeaponsAuth()
        {
            GetAllWeaponsRequest request = new GetAllWeaponsRequest();
            List<GetAllWeaponsViewModel> weapons = await _mediator.Send(request);
            return Ok(weapons);
        }
        [HttpGet("weaponsPlayer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = ConstantsAuthorization.Roles.PLAYER)]
        public async Task<ActionResult<List<GetAllWeaponsViewModel>>> WeaponsPlayer()
        {
            GetAllWeaponsRequest request = new GetAllWeaponsRequest();
            List<GetAllWeaponsViewModel> weapons = await _mediator.Send(request);
            return Ok(weapons);
        }
        #endregion
    }
}