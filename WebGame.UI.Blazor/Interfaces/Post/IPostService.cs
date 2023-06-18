using WebGame.UI.Blazor.DTO.Post;
using WebGame.UI.Blazor.Services;
using WebGame.UI.Blazor.ViewModels.Post;

namespace WebGame.UI.Blazor.Interfaces.Post
{
    public interface IPostService
    {
        Task<ICollection<ConversationsBlazorVM>> GetPagedConversations(int page, int pageSize);
        Task<ICollection<MessagesBlazorVM>> GetPagedMessages(int page, int pageSize, int id);
        Task AddMessage(MessageDTO message);
        Task RemoveConservation(int id);
        Task RemoveAllConservation();
        Task RemoveConservations(List<int> ids);
        Task<AddConversationCommandResponse> AddConversation(ConversationDTO conversation);
    }
}
