namespace WebGame.UI.Blazor.DTO.Post
{
    public class ConversationDTO
    {
        public int PlayerId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
    public class MessageDTO
    {
        public int ConservationId { get; set; }
        public string Text { get; set; }
        public int ToID { get; set; }
    }
}
