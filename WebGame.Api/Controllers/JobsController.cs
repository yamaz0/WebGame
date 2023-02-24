using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebGame.Application.Functions.Jobs.Command.Create;
using WebGame.Application.Functions.Jobs.Command.Delete;
using WebGame.Application.Functions.Jobs.Command.Update;
using WebGame.Application.Functions.Jobs.Query.GetAll;
using WebGame.Application.Functions.Jobs.Query.GetOne;
using WebGame.Domain.Entities.User;
using WebGame.Entities.Jobs;

namespace WebGame.Controllers
{
    [Authorize]
    public class JobsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        //private readonly UserManager<UserEntity> _userManager;

        //public JobsController(IJobService jobService, UserManager<UserEntity> userManager)
        //{
        //    _jobService = jobService;
        //    _userManager = userManager;
        //}

        //public IActionResult Index()
        //{
        //    var userId = _userManager.GetUserId(HttpContext.User);
        //    bool isPlayerWorking = _jobService.HasWork(userId);

        //    if (isPlayerWorking)
        //    {
        //        return RedirectToAction("JobDetail");
        //    }

        //    var jobs = _jobService.GetAllJobs();
        //    return View(jobs);
        //}

        //public IActionResult JobDetail()
        //{
        //    var userId = _userManager.GetUserId(HttpContext.User);
        //    bool isPlayerWorking = _jobService.HasWork(userId);

        //    if (!isPlayerWorking)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    var message = _jobService.TryReward(userId);

        //    TempData["Message"] = message;
        //    return View();
        //}

        //public IActionResult Job(int jobId)
        //{
        //    var userId = _userManager.GetUserId(HttpContext.User);
        //    _jobService.Job(userId, jobId);
        //    return RedirectToAction("JobDetail");
        //}

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<List<GetAllJobsViewModel>>> Get()
        {
            GetAllJobsRequest getAllJobsRequest = new GetAllJobsRequest();
            List<GetAllJobsViewModel> allJobs = await _mediator.Send(getAllJobsRequest);
            return allJobs;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetJobViewModel>> Get(int id)
        {
            GetJobRequest getJobRequest = new GetJobRequest() { JobId = id };
            GetJobViewModel job = await _mediator.Send(getJobRequest);
            return job;
        }

        // POST api/<ValuesController>
        [HttpPost]
        [Authorize("Administrator")]
        public async Task<ActionResult<int>> Post([FromBody] CreateJobCommand createJobCommand)
        {
            var result = await _mediator.Send(createJobCommand);
            return Ok(result.JobId);

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        [Authorize("Administrator")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateJobCommand updateJobCommand)
        {
            await _mediator.Send(updateJobCommand);
            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        [Authorize("Administrator")]
        public async Task<ActionResult> Delete(int id)
        {
            DeleteJobCommand deleteRequest = new DeleteJobCommand() { JobId = id };
            var result = await _mediator.Send(deleteRequest);
            return NoContent();
        }
    }
}