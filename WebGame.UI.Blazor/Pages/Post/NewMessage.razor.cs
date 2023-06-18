using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using WebGame.UI.Blazor.Interfaces.Post;
using WebGame.UI.Blazor.Services.Authentication;

namespace WebGame.UI.Blazor.Pages.Post
{
    public partial class NewMessage
    {
        [Inject]
        public IPostService PostService { get; set; }
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string Title { get; set; } = "Tytul tymczasowy";
        public int ToPlayerId { get; set; }
        public string MessageText { get; set; }

        public async void Send()
        {
            var result = await PostService.AddConversation(new DTO.Post.ConversationDTO() { PlayerId = ToPlayerId, Title = Title });
            int id = result.ConversationId;
            await PostService.AddMessage(new DTO.Post.MessageDTO() { ToID = ToPlayerId, Text = MessageText, ConservationId = id });

            int playerId = await Utils.Utils.GetPlayerId((CustomAuthenticationStateProvider)AuthenticationStateProvider);

            var q = NavigationManager.GetUriWithQueryParameters("conversation",
                new Dictionary<string, object?>()
                {
                    {nameof(Conversation.Id),id},
                    {nameof(Conversation.FromId),playerId},
                    {nameof(Conversation.ToId),ToPlayerId},
                    {nameof(Conversation.Title),Title}
                });

            NavigationManager.NavigateTo(q);
        }
    }
}
