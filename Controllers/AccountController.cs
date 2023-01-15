using Microsoft.AspNetCore.Mvc;

namespace WebGame.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
