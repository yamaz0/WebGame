using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Text;
using WebGame.UI.Blazor.Constants;
using WebGame.UI.Blazor.Interfaces.Post;
using WebGame.UI.Blazor.Services.Authentication;
using WebGame.UI.Blazor.ViewModels.Post;

namespace WebGame.UI.Blazor.Pages.Post
{
    public partial class Conversation
    {
        [Inject]
        public IPostService PostService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Parameter]
        public int Id { get; set; }
        [Parameter]
        public string Title { get; set; }

        public int PlayerId { get; set; } = -1;
        public List<MessagesBlazorVM> Messages { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await TrySetPlayerId();
            //get title,id,messages by id from previus page
        }

        private async Task TrySetPlayerId()
        {
            var authState = await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();

            foreach (var claim in authState.User.Claims)
            {
                bool canParse = int.TryParse(claim.Value, out int parsedPlayerId);

                if (claim.Type == Constants.CustomConstants.Claims.PLAYERID && canParse)
                {
                    PlayerId = parsedPlayerId;
                }
                else
                {
                    throw new Exception("playerId not found");
                }
            }
        }
    }
}
