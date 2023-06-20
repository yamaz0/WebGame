namespace WebGame.Domain.Entities.Post
{
    public class Conversation
    {
        public int Id { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public string Title { get; set; }
        public bool IsFromIdRemoved { get; set; }
        public bool IsToIdRemoved { get; set; }
        public DateTime LastModificationDate { get; set; }
        public List<Message> Messages { get; set; }

        public void Init(string title, int fromPlayerId, int toPlayerId)
        {
            Title = title;
            FromId = fromPlayerId;
            ToId = toPlayerId;
        }
    }
}