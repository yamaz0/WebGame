using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGame.Application.Functions.Enemies.Query.GetAllEnemies;

namespace WebGame.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ArenaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArenaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllEnemiesViewModel>>>Index()
        {
            List<GetAllEnemiesViewModel> enemies = await _mediator.Send(new GetAllEnemiesRequest());
            return Ok(enemies);
        }
    }
}
