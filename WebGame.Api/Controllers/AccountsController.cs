using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGame.Application.Functions.Account.Command.Login;
using WebGame.Application.Functions.Account.Command.Logout;
using WebGame.Application.Functions.Accounts.Command.Create;
using WebGame.Application.Functions.Players.Query.GetPlayer;

namespace WebGame.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginCommandResponse>> Login([FromBody] LoginCommand request)
        {
            var result = await _mediator.Send(request);
            var userid = result.AuthenticationResponse.UserId;
            //HttpContext.Response.Cookies.Append("UserId", userid);
            return Ok(result);
        }

        [HttpPost("Logout")]
        public async Task<ActionResult> Logout()
        {
            var result = await _mediator.Send(new LogoutCommand());
            return Ok();
        }

        [HttpPost("Register")]
        public async Task<ActionResult<CreateUserCommandResponse>> Register([FromBody] CreateUserCommand request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _mediator.Send(request);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
