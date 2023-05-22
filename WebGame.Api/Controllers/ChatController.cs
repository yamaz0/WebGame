using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebGame.Api.Common;
using WebGame.Application.Functions.Posts;
using WebGame.Application.Functions.Posts.Conversation.AddConversation;
using WebGame.Application.Functions.Posts.Conversation.GetConversations;
using WebGame.Application.Functions.Posts.Message.AddMessage;
using WebGame.Application.Functions.Posts.Message.GetMessages;
using WebGame.Application.Response;

namespace WebGame.Api.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _config;

        public ChatController(IMediator mediator, IConfiguration config)
        {
            _mediator = mediator;
            _config = config;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPost("addc")]
        public async Task<ActionResult<BasicResponse>> AddPost([FromBody] AddConversationCommand request)
        {
            var playerId = Utils.GetPlayerId(User);
            request.PlayerId = playerId;
            var result = await _mediator.Send(request);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet("c")]
        public async Task<ActionResult<BasicResponse>> GetPW()
        {
            var playerId = Utils.GetPlayerId(User);
            GetPagedConversationRequest request = new GetPagedConversationRequest(1, 5, _config.GetValue<int>("Test:PlayerId"));
            var result = await _mediator.Send(request);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPost("addm")]
        public async Task<ActionResult<BasicResponse>> AddMessage([FromBody] AddMessageCommand request)
        {
            var playerId = Utils.GetPlayerId(User);
            request.PlayerId = playerId;
            var result = await _mediator.Send(request);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet("m")]
        public async Task<ActionResult<BasicResponse>> GetMessage()
        {
            var playerId = Utils.GetPlayerId(User);
            GetPagedMessagesRequest request = new GetPagedMessagesRequest(1, 5, _config.GetValue<int>("Test:ConvId"));
            var result = await _mediator.Send(request);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

    }
}
