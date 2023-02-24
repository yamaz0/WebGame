using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebGame.Application.Functions.Players.Query.GetPlayer;
using WebGame.Domain.Entities.User;

namespace WebGame.Controllers
{
    [Authorize]
    public class PlayersController : Controller
    {
        //private readonly UserManager<UserEntity> _userManager;
        private readonly IMediator _mediator;

        public PlayersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ActionResult<GetPlayerViewModel>> Index()
        {
            //var userId = _userManager.GetUserId(HttpContext.User);
            GetPlayerViewModel player = await _mediator.Send(new GetPlayerRequest() { PlayerId = 0 });
            return Ok(player);
        }
    }
}
