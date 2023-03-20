using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebGame.Application.Functions.Jobs.Command.Create;
using WebGame.Application.Functions.Jobs.Command.Delete;
using WebGame.Application.Functions.Jobs.Command.Update;
using WebGame.Application.Functions.Jobs.Query.GetAllJobs;
using WebGame.Application.Functions.Jobs.Query.GetJob;
using WebGame.Application.Functions.Jobs.Command.Delete;
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

        [HttpGet("jobs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetAllJobsViewModel>>> Jobs()
        {
            List<GetAllJobsViewModel> jobs = await _mediator.Send(new GetAllJobsRequest());
            return Ok(jobs);
        }

        [HttpGet("jobs/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetJobViewModel>> Jobs(int id)
        {
            GetJobRequest getJobRequest = new GetJobRequest(id);
            GetJobViewModel job = await _mediator.Send(getJobRequest);

            if (job == null)
                return NotFound();
            return Ok(job);
        }

        [HttpPost("jobs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        //[Authorize("Administrator")]
        public async Task<ActionResult<int>> Create([FromBody] CreateJobCommand createJobCommand)
        {
            var result = await _mediator.Send(createJobCommand);
            if (result.Success)
                return Ok(result.JobId);
            else
                return BadRequest(result.Errors);

        }

        [HttpPut("jobs")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        //[Authorize("Administrator")]
        public async Task<ActionResult> Update([FromBody] UpdateJobCommand updateJobCommand)
        {
            await _mediator.Send(updateJobCommand);
            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("jobs/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        //[Authorize("Administrator")]
        public async Task<ActionResult> Delete(int id)
        {
            DeleteJobCommand deleteRequest = new DeleteJobCommand(id);
            await _mediator.Send(deleteRequest);
            return NoContent();
        }
    }
}