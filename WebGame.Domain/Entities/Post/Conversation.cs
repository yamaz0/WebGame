namespace WebGame.Domain.Entities.Post
{
    public class Conversation
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string Title { get; set; }
        public List<Message> Messages { get; set; }

        public void Init(string title, int playerId)
        {
            Title = title;
            PlayerId = playerId;
        }
    }
}