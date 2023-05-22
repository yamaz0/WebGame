using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Response;
using WebGame.Domain.Entities.Post;

namespace WebGame.Application.Functions.Posts.Message.GetMessages
{
    public class GetPagedMessagesRequest : IRequest<GetPostMessagesRequestResponse>
    {
        public int ConversationID { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetPagedMessagesRequest(int page, int pageSize, int conversationID)
        {
            Page = page;
            PageSize = pageSize;
            ConversationID = conversationID;
        }
    }

    public class GetPostMessagesRequestHandler : IRequestHandler<GetPagedMessagesRequest, GetPostMessagesRequestResponse>
    {
        private readonly IMessageRepository _messageRepository;

        public GetPostMessagesRequestHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<GetPostMessagesRequestResponse> Handle(GetPagedMessagesRequest request, CancellationToken cancellationToken)
        {
            var messages = await _messageRepository.GetPagedMessagesAsync(request.ConversationID, request.Page, request.PageSize);
            return new GetPostMessagesRequestResponse(messages);
        }
    }
    public class GetPostMessagesRequestResponse : BasicResponse
    {
        public List<Domain.Entities.Post.Message> Messages { get; set; }

        public GetPostMessagesRequestResponse(List<Domain.Entities.Post.Message> messages)
        {
            Messages = messages;
        }
    }
}
