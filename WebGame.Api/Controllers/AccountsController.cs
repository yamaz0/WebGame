using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGame.Application.Functions.Account.Command;
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

        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Login(LoginModel loginModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(loginModel);
        //    }

        //    var result = _service.Login(loginModel);

        //    if (result.Result.Succeeded == false)
        //    {
        //        ModelState.AddModelError(String.Empty, "Invalid user name or password. Try again!");
        //        return View(loginModel);
        //    }

        //    return RedirectToAction("Index", "Home");
        //}

        //[HttpGet]
        //public IActionResult Register()
        //{
        //    return View();
        //}

        [HttpPost("Login")]
        public async Task<ActionResult<LoginCommandResponse>> Login([FromBody] LoginCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
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

        //[HttpGet]
        //[Authorize]
        //public IActionResult Logout()
        //{
        //    _service.Logout();
        //    return RedirectToAction("Index", "Home");
        //}
    }
}
