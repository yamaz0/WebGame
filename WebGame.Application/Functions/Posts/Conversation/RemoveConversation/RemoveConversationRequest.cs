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
    public class RemoveConversationRequest : IRequest<RemoveConversationRequestResponse>
    {
        public int ConversationId { get; set; }
        public int PlayerId { get; set; }

        public RemoveConversationRequest(int conversationId, int playerId)
        {
            ConversationId = conversationId;
            PlayerId = playerId;
        }
    }

    public class RemoveConversationRequestHandler : IRequestHandler<RemoveConversationRequest, RemoveConversationRequestResponse>
    {
        private readonly IConversationRepository _conversationRepository;

        public RemoveConversationRequestHandler(IConversationRepository conversationRepository)
        {
            _conversationRepository = conversationRepository;
        }

        public async Task<RemoveConversationRequestResponse> Handle(RemoveConversationRequest request, CancellationToken cancellationToken)
        {
            await _conversationRepository.RemoveConversationAsync(request.PlayerId, request.ConversationId);
            return new RemoveConversationRequestResponse();
        }
    }
    public class RemoveConversationRequestResponse : BasicResponse
    {
        public RemoveConversationRequestResponse()
        {

        }
        public RemoveConversationRequestResponse(string error) : base(error)
        {
        }
    }
}
