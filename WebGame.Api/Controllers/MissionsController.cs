using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGame.Application.Functions.Missions.Query.GetAll;

namespace WebGame.Controllers
{
    [Authorize]
    public class MissionsController : Controller
    {
        private readonly IMediator _mediator;

        public MissionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ActionResult<List<GetAllMissionsViewModel>>> Index()
        {
            List<GetAllMissionsViewModel> missions = await _mediator.Send(new GetAllMissionsRequest());
            return Ok(missions);
        }
    }
}
