using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebGame.Entities;
using WebGame.Services.Job.Interface;

namespace WebGame.Controllers
{
    [Authorize]
    public class JobsController : Controller
    {
        private readonly IJobService _jobService;

        private readonly UserManager<UserEntity> _userManager;

        public JobsController(IJobService jobService, UserManager<UserEntity> userManager)
        {
            _jobService = jobService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            bool isPlayerWorking = _jobService.HasWork(userId);

            if (isPlayerWorking)
            {
                return RedirectToAction("JobDetail");
            }

            var jobs = _jobService.GetAllJobs();
            return View(jobs);
        }

        public IActionResult JobDetail()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            bool isPlayerWorking = _jobService.HasWork(userId);

            if (!isPlayerWorking)
            {
                return RedirectToAction("Index");
            }

            var message = _jobService.TryReward(userId);

            TempData["Message"] = message;
            return View();
        }

        public IActionResult Job(int jobId)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            _jobService.Job(userId, jobId);
            return RedirectToAction("JobDetail");
        }
    }
}
