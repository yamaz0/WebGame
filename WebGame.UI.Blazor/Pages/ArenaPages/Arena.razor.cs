using Microsoft.AspNetCore.Components;
using WebGame.UI.Blazor.Interfaces.Arena;
using WebGame.UI.Blazor.Interfaces.Enemies;
using WebGame.UI.Blazor.Interfaces.Missions;
using WebGame.UI.Blazor.Services;
using WebGame.UI.Blazor.ViewModels.Enemies;

namespace WebGame.UI.Blazor.Pages.ArenaPages
{
    public partial class Arena
    {
        private bool isDuel = false;
        private DuelViewData duelData;


        public ICollection<AllEnemiesBlazorVM> Enemies { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IEnemiesService _enemiesServices { get; set; }
        [Inject]
        public IArenaEnemyService _arenaEnemyServices { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await FetchEnemies();
        }

        protected async Task Duel(int id)
        {
            var response = await _arenaEnemyServices.Duel(id);
            isDuel = response?.Success ?? false;
            duelData = response?.DuelViewData;
            StateHasChanged();
        }

        protected async void Back()
        {
            isDuel = false;
            await FetchEnemies();
        }

        private async Task FetchEnemies()
        {
            Enemies ??= await _enemiesServices.GetEnemies();
            StateHasChanged();
        }
    }
}
