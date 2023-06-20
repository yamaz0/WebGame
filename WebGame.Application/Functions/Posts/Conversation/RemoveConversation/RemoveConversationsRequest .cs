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
    public class RemoveConversationsRequest : IRequest<RemoveConversationsRequestResponse>
    {
        public List<int> ConversationsIds { get; set; }
        public int PlayerId { get; set; }

        public RemoveConversationsRequest(List<int> conversationsIds)
        {
            ConversationsIds = conversationsIds;
        }
    }

    public class RemoveConversationsRequestHandler : IRequestHandler<RemoveConversationsRequest, RemoveConversationsRequestResponse>
    {
        private readonly IConversationRepository _conversationRepository;

        public RemoveConversationsRequestHandler(IConversationRepository conversationRepository)
        {
            _conversationRepository = conversationRepository;
        }

        public async Task<RemoveConversationsRequestResponse> Handle(RemoveConversationsRequest request, CancellationToken cancellationToken)
        {
            await _conversationRepository.RemoveConversationsAsync(request.PlayerId, request.ConversationsIds);
            return new RemoveConversationsRequestResponse();
        }
    }
    public class RemoveConversationsRequestResponse : BasicResponse
    {
        public RemoveConversationsRequestResponse()
        {

        }
        public RemoveConversationsRequestResponse(string error) : base(error)
        {
        }
    }
}
