﻿using Blazored.LocalStorage;
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
            await TrySetPlayerId();
            //get title,id,messages by id from previus page
            Messages = await PostService.GetPagedMessages(1, 5, Id);//domyslne wartosci potem ustawic globalnie
        }

        private async Task TrySetPlayerId()
        {
            var authState = await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();

            foreach (var claim in authState.User.Claims)
            {

                if (claim.Type == CustomConstants.Claims.PLAYERID)
                {
                    bool canParse = int.TryParse(claim.Value, out int parsedPlayerId);

                    if (canParse)
                        PlayerId = parsedPlayerId;
                    else
                    {
                        throw new Exception("playerId not found");
                    }
                }
            }
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
            //refresh czy cos
        }

        public void Delete()
        {

        }
    }
}
