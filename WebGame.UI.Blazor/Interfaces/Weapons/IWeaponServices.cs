using WebGame.UI.Blazor.ViewModels.Weapons;

namespace WebGame.UI.Blazor.Interfaces.Weapons
{
    public interface IWeaponServices
    {
        Task BuyWeapon(int id);
        Task<List<WeaponsListBlazorVM>> GetAllWeapons();
    }
}
