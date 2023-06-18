using Microsoft.AspNetCore.Components;
using WebGame.UI.Blazor.Interfaces.Post;
using WebGame.UI.Blazor.ViewModels.Post;

namespace WebGame.UI.Blazor.Pages.Post
{
    public partial class Post
    {
        [Inject]
        public IPostService PostService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<ConversationsBlazorVM> Conversations { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //get paged conversations
            Conversations = await PostService.GetPagedConversations(1, 5);
        }

        public void NewMessage()
        {
            NavigationManager.NavigateTo("/newMessage");
        }

        private void ShowMessages(ConversationsBlazorVM c)
        {
            var q = NavigationManager.GetUriWithQueryParameters("conversation",
                new Dictionary<string, object?>()
                {
                    {nameof(Conversation.Id),c.Id},
                    {nameof(Conversation.FromId),c.FromId},
                    {nameof(Conversation.ToId),c.ToId},
                    {nameof(Conversation.Title),c.Title}
                });

            NavigationManager.NavigateTo(q);
        }
    }
}
