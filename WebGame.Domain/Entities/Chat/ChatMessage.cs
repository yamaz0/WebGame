using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Domain.Entities.Player;

namespace WebGame.Domain.Entities.Chat
{
    public class Chat
    {
        public int FromPlayerId { get; set; }
        public int ToPlayerId { get; set; }
        public List<ChatMessage> Messages { get; set; }
        public virtual Player.Player FromPlayer { get; set; }
        public virtual Player.Player ToPlayer { get; set; }
    }

    public class ChatMessage
    {
        public long Id { get; set; }
        public string FromPlayerId { get; set; }
        public string ToPlayerId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
