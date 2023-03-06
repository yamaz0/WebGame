using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebGame.Application.Functions.Duel.Command;

namespace WebGame.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class DuelController : ControllerBase
    {
        //private readonly UserManager<UserEntity> _userManager;

        //public DuelController(UserManager<UserEntity> userManager)
        //{
        //    _userManager = userManager;
        //}
        private readonly IMediator _mediator;

        public DuelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("duel/{enemyId}")]
        public async Task<ActionResult<DuelPlayerVsEnemyResponse>> DuelEnemy(int enemyId)
        {
            //TODO pobieranie idków
            //var userId = _userManager.GetUserId(HttpContext.User);
            DuelPlayerVsEnemyResponse response = await _mediator.Send(new DuelPlayerVsEnemyCommand() { EnemyId = 1, PlayerId = 1 });

            if (response == null)
                return NotFound();
            else
                return Ok(response);
        }
    }
}