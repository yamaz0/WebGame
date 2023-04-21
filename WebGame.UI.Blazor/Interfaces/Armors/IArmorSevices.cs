using WebGame.UI.Blazor.ViewModels.Armors;

namespace WebGame.UI.Blazor.Interfaces.Armors
{
    public interface IArmorServices
    {
        Task BuyArmor(int id);
        Task<List<ArmorsListBlazorVM>> GetAllArmors();
    }
}
