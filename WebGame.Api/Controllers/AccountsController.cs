using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGame.Application.Functions.Account.Command.Login;
using WebGame.Application.Functions.Account.Command.RefreshToken;
using WebGame.Application.Functions.Accounts.Command.Create;

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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpPost("Login")]
        public async Task<ActionResult<LoginCommandResponse>> Login([FromBody] LoginCommand request)
        {
            var result = await _mediator.Send(request);
            var userid = result.AuthenticationResponse.UserId;
            //HttpContext.Response.Cookies.Append("UserId", userid);
            return Ok(result);
        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpPost("RefreshToken")]
        public async Task<ActionResult<RefreshTokenCommandResponse>> Refresh()
        {
            var result = await _mediator.Send(new RefreshTokenCommand(User));
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpPost("Logout")]
        public async Task<ActionResult> Logout()//do wywalenia
        {
            //var result = await _mediator.Send(new LogoutCommand());
            await HttpContext.SignOutAsync();
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
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
