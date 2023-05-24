using WebGame.UI.Blazor.DTO.Post;
using WebGame.UI.Blazor.Services;
using WebGame.UI.Blazor.ViewModels.Post;

namespace WebGame.UI.Blazor.Interfaces.Post
{
    public interface IPostService
    {
        Task<ICollection<ConversationsBlazorVM>> GetPagedConversations();
        Task<ICollection<MessagesBlazorVM>> GetPagedMessages();
        Task AddConversation(ConversationDTO conversation);
        Task AddMessage(MessageDTO message);
    }
}
