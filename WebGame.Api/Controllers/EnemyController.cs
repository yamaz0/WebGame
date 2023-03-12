using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGame.Application.Functions.Enemies.Query.GetAllEnemies;
using WebGame.Application.Functions.Enemies.Query.GetEnemy;

namespace WebGame.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EnemyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EnemyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("enemies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetAllEnemiesViewModel>>> Enemies()
        {
            List<GetAllEnemiesViewModel> enemies = await _mediator.Send(new GetAllEnemiesRequest());
            return Ok(enemies);
        }

        [HttpGet("enemies/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetEnemyViewModel>> Enemies(int id)
        {
            GetEnemyRequest request = new GetEnemyRequest(id);
            GetEnemyViewModel enemy = await _mediator.Send(request);
            if (enemy == null)
                return NotFound();
            return Ok(enemy);
        }
    }
}
