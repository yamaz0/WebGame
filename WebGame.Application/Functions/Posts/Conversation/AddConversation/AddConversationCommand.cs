using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.Posts.Conversation.AddConversation
{
    public class AddConversationCommand : IRequest<AddConversationCommandResponse>
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public int PlayerId { get; set; }
        public int ToID { get; set; }

        public AddConversationCommand(int playerId, string title, string message, int toID)
        {
            PlayerId = playerId;
            Title = title;
            Message = message;
            ToID = toID;
        }
    }

    public class AddConversationCommandHandler : IRequestHandler<AddConversationCommand, AddConversationCommandResponse>
    {
        private readonly IConversationRepository _conversationRepository;

        public AddConversationCommandHandler(IConversationRepository conversationRepository)
        {
            _conversationRepository = conversationRepository;
        }

        public async Task<AddConversationCommandResponse> Handle(AddConversationCommand request, CancellationToken cancellationToken)
        {
            //TODO zrobic klase do wiadomosci i zrobic post.createConservation i post.sendMessage jako tworzenie pierwszej wiadomosci w rozmowie
            var conversation = new Domain.Entities.Post.Conversation();
            conversation.Init(request.Title, request.PlayerId, request.ToID);

            conversation = await _conversationRepository.AddAsync(conversation);
            return new AddConversationCommandResponse(conversation.Id);
        }
    }
    public class AddConversationCommandResponse : BasicResponse
    {
        public int ConversationId { get; set; }

        public AddConversationCommandResponse(int conversationId)
        {
            ConversationId = conversationId;
        }
    }
}
