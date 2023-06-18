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

        public RemoveConversationRequest(int conversationId)
        {
            ConversationId = conversationId;
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
            var conversation = await _conversationRepository.GetByIdAsync(request.ConversationId);

            if (conversation == null)
            {
                return new RemoveConversationRequestResponse("Conversation not found");
            }

            await _conversationRepository.RemoveAsync(conversation);
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
