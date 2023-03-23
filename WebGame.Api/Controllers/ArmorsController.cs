using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebGame.Application.Functions.Armors.Query.GetAllArmors;
using WebGame.Application.Functions.Enemies.Query.GetArmor;

namespace WebGame.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ArmorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArmorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("armors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetAllArmorsViewModel>>> Armors()
        {
            GetAllArmorsRequest request = new GetAllArmorsRequest();
            List<GetAllArmorsViewModel> armors = await _mediator.Send(request);
            return Ok(armors);
        }

        [HttpGet("armors/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetArmorViewModel>> Armors(int id)
        {
            var request = new GetArmorRequest(id);
            GetArmorViewModel armor = await _mediator.Send(request);
            if (armor == null)
                return NotFound();
            return Ok(armor);
        }
    }
}