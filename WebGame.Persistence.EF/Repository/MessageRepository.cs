using Microsoft.EntityFrameworkCore;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Domain.Entities.Post;

namespace WebGame.Persistence.EF.Repository
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(DbGameContext context) : base(context)
        {
        }

        public async Task<List<Message>> GetPagedMessagesAsync(int conversationId, int page, int pageSize)
        {
            int skipElementsNumber = (page - 1) * pageSize;
            return await _context.Messages.Where(m => m.ConservationId == conversationId).Skip(skipElementsNumber).Take(pageSize).AsNoTracking().ToListAsync();
        }
    }
}
