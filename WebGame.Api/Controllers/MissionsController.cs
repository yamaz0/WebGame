using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGame.Application.Functions.Missions.Command.Create;
using WebGame.Application.Functions.Missions.Command.Delete;
using WebGame.Application.Functions.Missions.Command.Update;
using WebGame.Application.Functions.Missions.Query.GetMission;
using WebGame.Application.Functions.Missions.Query.GetAllMissions;
using WebGame.Application.Functions.Missions.Command;
using WebGame.Api.Common;

namespace WebGame.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MissionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MissionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("missions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetAllMissionsViewModel>>> Missions()
        {
            List<GetAllMissionsViewModel> missions = await _mediator.Send(new GetAllMissionsRequest());
            return Ok(missions);
        }

        [HttpGet("missions/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetMissionViewModel>> Missions(int id)
        {
            GetMissionRequest getMissionRequest = new GetMissionRequest(id);
            GetMissionViewModel mission = await _mediator.Send(getMissionRequest);

            if (mission == null)
                return NotFound();
            return Ok(mission);
        }

        [HttpPost("missions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Authorize("Administrator")]
        public async Task<ActionResult<int>> Create([FromBody] CreateMissionCommand createMissionCommand)
        {
            var result = await _mediator.Send(createMissionCommand);
            if (result.Success)
                return Ok(result.MissionId);
            else
                return BadRequest(result.Errors);
        }

        [HttpPost("mission/check")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<ActionResult<int>> Check([FromBody] CheckMissionCommand checkMissionCommand)
        {
            int playerId = Utils.GetPlayerId(User);
            checkMissionCommand.PlayerId = playerId;
            var result = await _mediator.Send(checkMissionCommand);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Errors);

        }

        [HttpPut("mission")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Authorize("Administrator")]
        public async Task<ActionResult> Update([FromBody] UpdateMissionCommand updateMissionCommand)
        {
            await _mediator.Send(updateMissionCommand);
            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("mission/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Authorize("Administrator")]
        public async Task<ActionResult> Delete(int id)
        {
            DeleteMissionCommand deleteRequest = new DeleteMissionCommand(id);
            await _mediator.Send(deleteRequest);
            return NoContent();
        }
    }
}
