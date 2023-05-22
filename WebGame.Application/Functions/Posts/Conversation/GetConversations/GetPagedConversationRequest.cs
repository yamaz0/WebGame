using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.Posts.Conversation.GetConversations
{
    public class GetPagedConversationRequest : IRequest<GetPagedConversationRequestResponse>
    {
        public int PlayerId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetPagedConversationRequest(int page, int pageSize, int playerId)
        {
            Page = page;
            PageSize = pageSize;
            PlayerId = playerId;
        }
    }

    public class GetPagedConversationRequestHandler : IRequestHandler<GetPagedConversationRequest, GetPagedConversationRequestResponse>
    {
        private readonly IConversationRepository _conversationRepository;

        public GetPagedConversationRequestHandler(IConversationRepository conversationRepository)
        {
            _conversationRepository = conversationRepository;
        }

        public async Task<GetPagedConversationRequestResponse> Handle(GetPagedConversationRequest request, CancellationToken cancellationToken)
        {
            var conversations = await _conversationRepository.GetPagedConversationsAsync(request.PlayerId, request.Page, request.PageSize);
            return new GetPagedConversationRequestResponse(conversations);
        }
    }
    public class GetPagedConversationRequestResponse : BasicResponse
    {
        public List<Domain.Entities.Post.Conversation> Conversations { get; set; }

        public GetPagedConversationRequestResponse(List<Domain.Entities.Post.Conversation> conversations)
        {
            Conversations = conversations;
        }
    }
}
