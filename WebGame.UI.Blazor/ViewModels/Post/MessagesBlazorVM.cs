namespace WebGame.UI.Blazor.ViewModels.Post
{
    public class MessagesBlazorVM
    {
        public int Id { get; set; }
        public int ConservationId { get; set; }
        public string Text { get; set; }
        public int FromID { get; set; }
        public int ToID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
