using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGame.Application.Functions.Jobs.Command.RewardJob;
using WebGame.Application.Functions.Jobs.Command.StartJob;
using WebGame.Application.Functions.Jobs.Command;
using WebGame.Application.Response;
using WebGame.Api.Common;

namespace WebGame.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("job/check")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<ActionResult<TimeActionResponse>> CheckJob()
        {
            int playerId = Utils.GetPlayerId(User);
            CheckJobCommand checkJobCommand = new CheckJobCommand(playerId);

            var result = await _mediator.Send(checkJobCommand);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Errors);
        }

        [HttpPost("job/start")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<ActionResult<BasicResponse>> JobStart([FromBody] int duration)
        {
            int playerId = Utils.GetPlayerId(User);
            StartJobCommand startJobCommand = new StartJobCommand(playerId, duration);

            var result = await _mediator.Send(startJobCommand);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Errors);
        }

        [HttpPost("job/reward")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<ActionResult<BasicResponse>> JobReward()
        {
            int playerId = Utils.GetPlayerId(User);
            RewardJobCommand rewardJobCommand = new RewardJobCommand(playerId);

            var result = await _mediator.Send(rewardJobCommand);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Errors);
        }
    }
}