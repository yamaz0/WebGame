using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Response;
using WebGame.Domain.Entities.Post;

namespace WebGame.Application.Functions.Posts.Message.AddMessage
{
    public class AddMessageCommand : IRequest<BasicResponse>
    {
        public int PlayerId { get; set; }
        public string Message { get; set; }
        public int ConversationID { get; set; }
        public int ToID { get; set; }

        public AddMessageCommand(int playerId, string message, int toID, int conversationID)
        {
            PlayerId = playerId;
            Message = message;
            ToID = toID;
            ConversationID = conversationID;
        }
    }

    public class AddMessageCommandHandler : IRequestHandler<AddMessageCommand, BasicResponse>
    {
        private readonly IMessageRepository _messageRepository;

        public AddMessageCommandHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<BasicResponse> Handle(AddMessageCommand request, CancellationToken cancellationToken)
        {
            var message = new Domain.Entities.Post.Message();
            message.SetMessage(request.Message, request.PlayerId, request.ToID, request.ConversationID);

            await _messageRepository.AddAsync(message);
            return new BasicResponse();
        }
    }
}
