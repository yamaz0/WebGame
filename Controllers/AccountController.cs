using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGame.Models.Account;
using WebGame.Services.Account.Interface;

namespace WebGame.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var result = _service.Login(loginModel);

            if (result.Result.Succeeded == false)
            {
                ModelState.AddModelError(String.Empty, "Invalid user name or password. Try again!");
                return View(loginModel);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var result = _service.Register(registerModel);

                if (result.Result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Result.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                }
            }
            return View(registerModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Logout()
        {
            _service.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
