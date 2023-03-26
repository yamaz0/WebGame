using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebGame.Api.Common;
using WebGame.Application.Constants;
using WebGame.Application.Functions.Duel.Command;

namespace WebGame.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DuelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DuelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("duel/{enemyId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<ActionResult<DuelPlayerVsEnemyResponse>> DuelEnemy(int enemyId)
        {
            int playerId = Utils.GetPlayerId(User);

            if (playerId == -1)
                return StatusCode(418);

            DuelPlayerVsEnemyResponse response = await _mediator.Send(new DuelPlayerVsEnemyCommand() { EnemyId = enemyId, PlayerId = playerId });

            if (response == null)
                return NotFound();
            else
                return Ok(response);
        }

    }
}