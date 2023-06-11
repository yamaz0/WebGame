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
            Conversations = await PostService.GetPagedConversations();
        }
        private void ShowMessages(int id)
        {
            NavigationManager.NavigateTo($"conversation/{id}");
        }
    }
}
