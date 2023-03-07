using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebGame.Application.Functions.Jobs.Command.Create;
using WebGame.Application.Functions.Jobs.Command.Delete;
using WebGame.Application.Functions.Jobs.Command.Update;
using WebGame.Application.Functions.Jobs.Query.GetAllJobs;
using WebGame.Application.Functions.Jobs.Query.GetJob;
using WebGame.Domain.Entities.User;
using WebGame.Entities.Jobs;

namespace WebGame.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<List<GetAllJobsViewModel>>> Get()
        {
            GetAllJobsRequest getAllJobsRequest = new GetAllJobsRequest();
            List<GetAllJobsViewModel> allJobs = await _mediator.Send(getAllJobsRequest);
            return Ok(allJobs);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetJobViewModel>> Get(int id)
        {
            GetJobRequest getJobRequest = new GetJobRequest() { JobId = id };
            GetJobViewModel job = await _mediator.Send(getJobRequest);
            return Ok(job);
        }

        // POST api/<ValuesController>
        [HttpPost]
        //[Authorize("Administrator")]
        public async Task<ActionResult<int>> Post([FromBody] CreateJobCommand createJobCommand)
        {
            var result = await _mediator.Send(createJobCommand);
            return Ok(result.JobId);

        }

        // PUT api/<ValuesController>/5
        [HttpPut("UpdateJob")]
        //[Authorize("Administrator")]
        public async Task<ActionResult> Put([FromBody] UpdateJobCommand updateJobCommand)
        {
            await _mediator.Send(updateJobCommand);
            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        //[Authorize("Administrator")]
        public async Task<ActionResult> Delete(int id)
        {
            DeleteJobCommand deleteRequest = new DeleteJobCommand() { JobId = id };
            var result = await _mediator.Send(deleteRequest);
            return NoContent();
        }
    }
}