namespace WebGame.UI.Blazor.ViewModels.Post
{
    public class ConversationsBlazorVM
    {
        public int Id { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public bool IsFromIdRemoved { get; set; }
        public bool IsToIdRemoved { get; set; }
        public DateTime LastModificationDate { get; set; }
        public string Title { get; set; }
    }
}
