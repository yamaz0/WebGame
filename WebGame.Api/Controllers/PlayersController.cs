﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebGame.Application.Functions.Players.Query.GetPlayer;
using WebGame.Domain.Entities.User;

namespace WebGame.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        //private readonly UserManager<UserEntity> _userManager;
        private readonly IMediator _mediator;

        public PlayersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<GetPlayerViewModel>> Index()
        {
            //var userId = _userManager.GetUserId(HttpContext.User);
            GetPlayerViewModel player = await _mediator.Send(new GetPlayerRequest() { PlayerId = 1 });
            return Ok(player);
        }
    }
}
