using WebGame.Application.Interfaces.Persistence.Common;
using WebGame.Domain.Entities.Post;
using WebGame.Entities.Items;

namespace WebGame.Application.Interfaces.Persistence
{
    public interface IConversationRepository : IAsyncRepository<Conversation>
    {
        Task<List<Conversation>> GetPagedConversationsAsync(int playerId, int page, int pageSize);
        Task<Conversation> GetConversationByIdAsync(int id, int playerId);
        Task RemoveConversationsAsync(int playerId, List<int> ids);
        Task RemoveAllConversationsAsync(int playerId);
        Task RemoveConversationAsync(int playerId, int id);
    }
}
