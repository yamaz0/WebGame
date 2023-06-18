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
    public class RemoveAllConversationRequest : IRequest<RemoveAllConversationRequestResponse>
    {
        public int PlayerId { get; set; }

        public RemoveAllConversationRequest(int playerId)
        {
            PlayerId = playerId;
        }
    }

    public class RemoveAllConversationRequestHandler : IRequestHandler<RemoveAllConversationRequest, RemoveAllConversationRequestResponse>
    {
        private readonly IConversationRepository _conversationRepository;

        public RemoveAllConversationRequestHandler(IConversationRepository conversationRepository)
        {
            _conversationRepository = conversationRepository;
        }

        public async Task<RemoveAllConversationRequestResponse> Handle(RemoveAllConversationRequest request, CancellationToken cancellationToken)
        {
             await _conversationRepository.RemoveAllConversationsAsync(request.PlayerId);

            return new RemoveAllConversationRequestResponse();
        }
    }
    public class RemoveAllConversationRequestResponse : BasicResponse
    {
        public RemoveAllConversationRequestResponse()
        {

        }
        public RemoveAllConversationRequestResponse(string error) : base(error)
        {
        }
    }
}
