using Microsoft.AspNetCore.Components;
using WebGame.UI.Blazor.Interfaces.Armors;
using WebGame.UI.Blazor.ViewModels.Armors;

namespace WebGame.UI.Blazor.Pages.ShopPages
{
    public partial class ShopArmors
    {
        [Inject]
        public IArmorServices ArmorService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<ArmorsListBlazorVM> Armors { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Armors = await ArmorService.GetAllArmors();
        }

        public async Task Buy(int id)
        {
            await ArmorService.BuyArmor(id);
        }
    }
}
