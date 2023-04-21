using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebGame.Api.Common;
using WebGame.Application.Functions.Players.Command.AddedStats;
using WebGame.Application.Functions.Players.Command.Update;
using WebGame.Application.Functions.Players.Query.GetPlayer;
using WebGame.Domain.Entities.User;

namespace WebGame.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlayersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("player/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetPlayerViewModel>> GetPlayer(int id)
        {
            GetPlayerViewModel player = await _mediator.Send(new GetPlayerRequest() { PlayerId = id });
            return Ok(player);
        }
        [HttpGet("player")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<ActionResult<GetPlayerAllInfoViewModel>> GetPlayer()
        {
            int playerId = Utils.GetPlayerId(User);

            if (playerId == -1)
                return StatusCode(418);

            GetPlayerAllInfoViewModel player = await _mediator.Send(new GetPlayerAllInfoRequest() { PlayerId = playerId });
            return Ok(player);
        }

        [HttpPut("player")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<ActionResult<GetPlayerViewModel>> Update([FromBody] UpdatePlayerCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpPut("addStat")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<ActionResult<GetPlayerViewModel>> AddStat([FromBody] AddedStatsPlayerCommand request)
        {
            int playerId = Utils.GetPlayerId(User);

            if (playerId == -1)
                return StatusCode(418);

            request.PlayerId = playerId;

            await _mediator.Send(request);
            return NoContent();
        }
    }
}
