using Microsoft.AspNetCore.Identity;
using WebGame.Domain.Entities.Chat;

namespace WebGame.Domain.Entities.User
{
    public class UserEntity : IdentityUser
    {
        //public virtual ICollection<ChatMessage> ChatMessagesFromUsers { get; set; }
        //public virtual ICollection<ChatMessage> ChatMessagesToUsers { get; set; }

        public UserEntity()
        {
            //ChatMessagesFromUsers = new HashSet<ChatMessage>();
            //ChatMessagesToUsers = new HashSet<ChatMessage>();
        }
    }
}
