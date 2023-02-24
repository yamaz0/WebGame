using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGame.Application.Functions.Missions.Query.GetAll;

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
    }
}
