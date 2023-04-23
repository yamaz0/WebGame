using Microsoft.AspNetCore.Components;
using WebGame.UI.Blazor.Interfaces.Armors;
using WebGame.UI.Blazor.Interfaces.Players;
using WebGame.UI.Blazor.Interfaces.Weapons;
using WebGame.UI.Blazor.Services.Players;
using WebGame.UI.Blazor.ViewModels.Weapons;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebGame.UI.Blazor.Pages.ShopPages
{
    public partial class ShopWeapons
    {
        [Inject]
        public IWeaponServices WeaponService { get; set; }
        [Inject]
        public IPlayerServices PlayerServices { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<WeaponsListBlazorVM> Weapons { get; set; }
        public string Cash { get; set; }
        public string Weapon { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Weapons = await WeaponService.GetAllWeapons();

            await RefreshPlayerInfo();
        }

        private async Task RefreshPlayerInfo()
        {
            var player = await PlayerServices.GetPlayerView();
            Cash = player.Cash.ToString();
            Weapon = player.Weapon?.Name ?? "Nothing";
        }

        public async Task Buy(int id)
        {
            await WeaponService.BuyWeapon(id);
            await RefreshPlayerInfo();
            StateHasChanged();
        }
    }
}
