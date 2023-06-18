using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Interfaces.Persistence.Common;
using WebGame.Domain.Entities.Post;

namespace WebGame.Persistence.EF.Repository
{
    public class ConversationRepository : BaseRepository<Conversation>, IConversationRepository
    {
        public ConversationRepository(DbGameContext context) : base(context)
        {
        }

        public async Task<Conversation> GetConversationByIdAsync(int id, int playerId)
        {
            return await _context.Conversations.Where(c => (c.FromId == playerId || c.ToId == playerId) && c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Conversation>> GetPagedConversationsAsync(int playerId, int page, int pageSize)
        {
            int skipElementsNumber = (page - 1) * pageSize;
            return await _context.Conversations.Where(c => c.FromId == playerId || c.ToId == playerId).Skip(skipElementsNumber).Take(pageSize).AsNoTracking().ToListAsync();
        }

        public async Task RemoveConversationsAsync(List<int> ids)
        {
            var conversations = await _context.Conversations.Where(c => ids.Contains(c.Id)).ToListAsync();

            foreach (var c in conversations)
            {
                await RemoveAsync(c);
            }
        }

        public async Task RemoveAllConversationsAsync(int playerId)
        {
            var conversations = await _context.Conversations.Where(c => c.FromId == playerId || c.ToId == playerId).ToListAsync();

            foreach (var c in conversations)
            {
                await RemoveAsync(c);
            }
        }
    }
}
