using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
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
        [SupplyParameterFromQuery]
        public int Id { get; set; }
        [Parameter]
        [SupplyParameterFromQuery]
        public int ToId { get; set; }
        [Parameter]
        [SupplyParameterFromQuery]
        public int FromId { get; set; }
        [Parameter]
        [SupplyParameterFromQuery]
        public string Title { get; set; } = "Tytul tymczasowy";
        public string MessageText { get; set; }

        public int PlayerId { get; set; } = -1;
        public ICollection<MessagesBlazorVM> Messages { get; set; }

        private bool showAnserTextArea = false;

        protected async override Task OnInitializedAsync()
        {
            //{ nameof(c.Id),c.Id},
            //        { nameof(c.FromId),c.FromId},
            //        { nameof(c.ToId),c.ToId},
            //        { nameof(c.Title),c.Title}
            showAnserTextArea = false;
            PlayerId = await Utils.Utils.GetPlayerId((CustomAuthenticationStateProvider)AuthenticationStateProvider);
            //get title,id,messages by id from previus page
            await FetchMessages();
        }

        private async Task FetchMessages()
        {
            Messages = await PostService.GetPagedMessages(1, 5, Id);//domyslne wartosci potem ustawic globalnie
        }

        public void Answer()
        {
            showAnserTextArea = true;
        }

        public async void SendAnswer()
        {
            if (PlayerId == FromId)
            {
                await PostService.AddMessage(new DTO.Post.MessageDTO() { ConservationId = Id, Text = MessageText, ToID = ToId });
            }
            else
            {
                await PostService.AddMessage(new DTO.Post.MessageDTO() { ConservationId = Id, Text = MessageText, ToID = FromId });
            }

            showAnserTextArea = false;
            await FetchMessages();
            StateHasChanged();
            //refresh czy cos
        }

        public async void Delete()
        {
            bool confirmed = await JS.InvokeAsync<bool>("confirm", "Are you sure?");

            if (confirmed)
            {
                await PostService.RemoveConservation(Id);
                StateHasChanged();
            }
        }
    }
}
