using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGame.Application.Functions.Missions.Command.Create;
using WebGame.Application.Functions.Missions.Command.Delete;
using WebGame.Application.Functions.Missions.Command.Update;
using WebGame.Application.Functions.Missions.Query.GetMission;
using WebGame.Application.Functions.Missions.Query.GetAllMissions;

namespace WebGame.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class MissionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MissionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllMissionsViewModel>>> Index()
        {
            List<GetAllMissionsViewModel> missions = await _mediator.Send(new GetAllMissionsRequest());
            return Ok(missions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetMissionViewModel>> Get(int id)
        {
            GetMissionRequest getMissionRequest = new GetMissionRequest() { MissionId = id };
            GetMissionViewModel mission = await _mediator.Send(getMissionRequest);
            return Ok(mission);
        }

        [HttpPost]
        //[Authorize("Administrator")]
        public async Task<ActionResult<int>> Post([FromBody] CreateMissionCommand createMissionCommand)
        {
            var result = await _mediator.Send(createMissionCommand);
            return Ok(result.MissionId);

        }

        [HttpPut("UpdateMission")]
        //[Authorize("Administrator")]
        public async Task<ActionResult> Put([FromBody] UpdateMissionCommand updateMissionCommand)
        {
            await _mediator.Send(updateMissionCommand);
            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        //[Authorize("Administrator")]
        public async Task<ActionResult> Delete(int id)
        {
            DeleteMissionCommand deleteRequest = new DeleteMissionCommand() { MissionId = id };
            var result = await _mediator.Send(deleteRequest);
            return NoContent();
        }
    }
}
