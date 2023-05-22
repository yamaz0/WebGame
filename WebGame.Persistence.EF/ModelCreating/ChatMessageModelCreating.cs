using Microsoft.EntityFrameworkCore;
using WebGame.Domain.Entities.Chat;

namespace WebGame.Persistence.EF.ModelCreating
{
    public class ChatMessageModelCreating
    {
        public static void Configure(ModelBuilder builder)
        {
            //builder.Entity<ChatMessage>(entity =>
            //{
            //    entity.HasOne(d => d.FromUser)
            //        .WithMany(p => p.ChatMessagesFromUsers)
            //        .HasForeignKey(d => d.FromUserId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);
            //    entity.HasOne(d => d.ToUser)
            //        .WithMany(p => p.ChatMessagesToUsers)
            //        .HasForeignKey(d => d.ToUserId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);
            //});
        }
    }
}
