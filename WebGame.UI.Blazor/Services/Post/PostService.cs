using AutoMapper;
using WebGame.UI.Blazor.DTO.Post;
using WebGame.UI.Blazor.Interfaces.Authorization;
using WebGame.UI.Blazor.Interfaces.Post;
using WebGame.UI.Blazor.ViewModels.Missions;
using WebGame.UI.Blazor.ViewModels.Players;
using WebGame.UI.Blazor.ViewModels.Post;

namespace WebGame.UI.Blazor.Services.Post
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private IClient _client;
        private IAddBearerTokenService _addBearerTokenService;

        public PostService(IMapper mapper, IClient client, IAddBearerTokenService addBearerTokenService)
        {
            _mapper = mapper;
            _client = client;
            _addBearerTokenService = addBearerTokenService;
        }

        public Task AddConversation(ConversationDTO conversation)
        {
            throw new NotImplementedException();
        }

        public async Task AddMessage(MessageDTO message)
        {
            await _addBearerTokenService.AddBearerToken(_client);
            await _client.AddmessageAsync(new AddMessageCommand() { ConversationID = message.ConservationId, Message = message.Text, ToID = message.ToID });
        }

        public async Task<ICollection<ConversationsBlazorVM>> GetPagedConversations(int page, int pageSize)
        {
            await _addBearerTokenService.AddBearerToken(_client);
            var conversations = await _client.ConversationAsync(1);
            var mappedConversations = _mapper.Map<ICollection<ConversationsBlazorVM>>(conversations.Conversations);
            return mappedConversations;
        }

        public async Task<ICollection<MessagesBlazorVM>> GetPagedMessages(int page, int pageSize, int id)
        {
            await _addBearerTokenService.AddBearerToken(_client);
            var messages = await _client.MessageAsync(id);
            var mappedMessages = _mapper.Map<ICollection<MessagesBlazorVM>>(messages.Messages);
            return mappedMessages;
        }
    }
}
