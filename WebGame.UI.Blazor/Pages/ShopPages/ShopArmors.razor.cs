using Microsoft.AspNetCore.Components;
using WebGame.UI.Blazor.Interfaces.Armors;
using WebGame.UI.Blazor.Interfaces.Players;
using WebGame.UI.Blazor.ViewModels.Armors;

namespace WebGame.UI.Blazor.Pages.ShopPages
{
    public partial class ShopArmors
    {
        [Inject]
        public IArmorServices ArmorService { get; set; }
        [Inject]
        public IPlayerServices PlayerServices { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<ArmorsListBlazorVM> Armors { get; set; }
        public string Cash { get; set; }
        public string Helmet { get; set; }
        public string Armor { get; set; }
        public string Legs { get; set; }
        public string Boots { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Armors = await ArmorService.GetAllArmors();
            await RefreshPlayerInfo();
        }

        private async Task RefreshPlayerInfo()
        {
            var player = await PlayerServices.GetPlayerView();
            Cash = player.Cash.ToString();
            Helmet = player.Helmet?.Name ?? "Nothing";
            Armor = player.Armor?.Name ?? "Nothing";
            Legs = player.Legs?.Name ?? "Nothing";
            Boots = player.Boots?.Name ?? "Nothing";
        }

        public async Task Buy(int id)
        {
            await ArmorService.BuyArmor(id);
            await RefreshPlayerInfo();
            StateHasChanged();
        }
    }
}
