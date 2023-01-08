using Microsoft.AspNetCore.Mvc;
using WebGame.Services.Job.Interface;

namespace WebGame.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }
        public IActionResult Index()
        {
            var jobs = _jobService.GetAllJobs();
            return View(jobs);
        }
    }
}
