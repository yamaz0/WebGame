using WebGame.Application.Interfaces.Persistence.Common;
using WebGame.Domain.Entities.Post;

namespace WebGame.Application.Interfaces.Persistence
{
    public interface IMessageRepository : IAsyncRepository<Message>
    {
        Task<List<Message>> GetPagedMessagesAsync(int conversationId, int page, int pageSize);
    }
}
