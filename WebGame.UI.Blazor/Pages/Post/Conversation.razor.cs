using Microsoft.AspNetCore.Components;
using WebGame.UI.Blazor.Interfaces.Post;
using WebGame.UI.Blazor.ViewModels.Post;

namespace WebGame.UI.Blazor.Pages.Post
{
    public partial class Conversation
    {
        [Inject]
        public IPostService PostService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<MessagesBlazorVM> Messages { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //get messages by id from previus page
        }
    }
}
