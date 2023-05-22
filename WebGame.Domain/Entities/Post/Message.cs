namespace WebGame.Domain.Entities.Post
{
    public class Message
    {
        public int Id { get; set; }
        public int ConservationId { get; set; }
        public string Text { get; set; }
        public int FromID { get; set; }
        public int ToID { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Conversation Conservation { get; set; }

        public void SetMessage(string message, int fromID, int toID, int conservationId)
        {
            ConservationId = conservationId;
            Text = message;
            FromID = fromID;
            ToID = toID;
            CreatedDate = DateTime.UtcNow;
        }
    }
}
