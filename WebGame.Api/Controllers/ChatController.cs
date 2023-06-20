using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGame.Api.Common;
using WebGame.Application.Functions.Posts;
using WebGame.Application.Functions.Posts.Conversation.AddConversation;
using WebGame.Application.Functions.Posts.Conversation.GetConversations;
using WebGame.Application.Functions.Posts.Message.AddMessage;
using WebGame.Application.Functions.Posts.Message.GetMessages;
using WebGame.Application.Response;
using WebGame.Domain.Entities.Post;

namespace WebGame.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPost("addconversation")]
        public async Task<ActionResult<AddConversationCommandResponse>> AddConversation([FromBody] AddConversationCommand request)
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpDelete("deleteconversation/{id}")]
        public async Task<ActionResult<RemoveConversationRequestResponse>> DeleteConversation(int id)
        {
            var playerId = Utils.GetPlayerId(User);
            var result = await _mediator.Send(new RemoveConversationRequest(id, playerId));

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpDelete("deleteconversations")]
        public async Task<ActionResult<RemoveConversationRequestResponse>> DeleteConversations([FromBody] RemoveConversationsRequest request)
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpDelete("deleteallplayerconversations")]
        public async Task<ActionResult<RemoveConversationRequestResponse>> DeleteAllPlayerConversation()
        {
            var playerId = Utils.GetPlayerId(User);
            var result = await _mediator.Send(new RemoveAllConversationRequest(playerId));

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("conversation/{page}")]
        public async Task<ActionResult<GetPagedConversationRequestResponse>> GetConversations(int page)
        {
            var playerId = Utils.GetPlayerId(User);
            var request = new GetPagedConversationRequest(page, 5, playerId);
            //request.PlayerId = playerId;
            var result = await _mediator.Send(request);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPost("addmessage")]
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("message/{id}")]
        public async Task<ActionResult<GetPostMessagesRequestResponse>> GetMessages(int id)
        {
            var result = await _mediator.Send(new GetPagedMessagesRequest(1, 5, id));

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}