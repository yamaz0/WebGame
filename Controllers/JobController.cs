using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebGame.Entities;
using WebGame.Services.Job.Interface;

namespace WebGame.Controllers
{
    [Authorize]
    public class JobController : Controller
    {
        private readonly IJobService _jobService;

        private readonly UserManager<UserEntity> _userManager;

        public JobController(IJobService jobService, UserManager<UserEntity> userManager)
        {
            _jobService = jobService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var jobs = _jobService.GetAllJobs();
            return View(jobs);
        }

        public IActionResult Job(int jobId)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            _jobService.Job(userId, jobId);
            return RedirectToAction("Index", "Home");
        }
    }
}
