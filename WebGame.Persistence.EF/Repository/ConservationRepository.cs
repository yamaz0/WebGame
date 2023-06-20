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
            return await _context.Conversations.Where(
                c =>
                    ((c.FromId == playerId && c.IsFromIdRemoved == false)
                    || (c.ToId == playerId && c.IsToIdRemoved == false))
                    && c.Id == id)
                .AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<List<Conversation>> GetPagedConversationsAsync(int playerId, int page, int pageSize)
        {
            int skipElementsNumber = (page - 1) * pageSize;
            return await _context.Conversations.Where(
                c =>
                    (c.FromId == playerId && c.IsFromIdRemoved == false)
                    || (c.ToId == playerId && c.IsToIdRemoved == false))
                .Skip(skipElementsNumber).Take(pageSize).AsNoTracking().ToListAsync();
        }

        public async Task RemoveConversationsAsync(int playerId, List<int> ids)
        {
            var conversations = await _context.Conversations.Where(c => ids.Contains(c.Id)).ToListAsync();

            foreach (var c in conversations)
            {
                SetRemove(playerId, c);
                //await RemoveAsync(c);
            }
        }

        public async Task RemoveConversationAsync(int playerId, int id)
        {
            var conversation = await _context.Conversations.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (conversation == null) return;

            SetRemove(playerId, conversation);
        }

        public async Task RemoveAllConversationsAsync(int playerId)
        {
            var conversations = await _context.Conversations.Where(
                c => c.FromId == playerId || c.ToId == playerId)
                .ToListAsync();

            foreach (var c in conversations)
            {
                SetRemove(playerId, c);
                //await RemoveAsync(c);
            }
        }

        private async void SetRemove(int playerId, Conversation c)
        {
            if (c.ToId == playerId)
            {
                c.IsToIdRemoved = true;
            }
            else
            {
                c.IsFromIdRemoved = true;
            }
            await UpdateAsync(c);
        }
    }
}
