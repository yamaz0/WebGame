using Microsoft.AspNetCore.Components;
using WebGame.UI.Blazor.Interfaces.Armors;
using WebGame.UI.Blazor.Interfaces.Players;
using WebGame.UI.Blazor.Services;
using WebGame.UI.Blazor.ViewModels.Armors;
using WebGame.UI.Blazor.ViewModels.Players;

namespace WebGame.UI.Blazor.Pages.PlayerPages
{
    public partial class PlayerPage
    {
        [Inject]
        public IPlayerServices PlayerService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public PlayerBlazorVM Player { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await RefreshPlayer();
        }

        private async Task RefreshPlayer()
        {
            Player = await PlayerService.GetPlayerView();
            StateHasChanged();
        }

        public async Task AddStat(Statistic stat)
        {
            await PlayerService.AddStat(stat);
            await RefreshPlayer();
        }
    }
}
