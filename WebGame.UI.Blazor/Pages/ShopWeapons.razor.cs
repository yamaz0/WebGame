using Microsoft.AspNetCore.Components;
using WebGame.UI.Blazor.Interfaces.Armors;
using WebGame.UI.Blazor.Interfaces.Weapons;
using WebGame.UI.Blazor.ViewModels.Weapons;

namespace WebGame.UI.Blazor.Pages
{
    public partial class ShopWeapons
    {
        [Inject]
        public IWeaponServices WeaponService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<WeaponsListBlazorVM> Weapons { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Weapons = await WeaponService.GetAllWeapons();
        }
    }
}
