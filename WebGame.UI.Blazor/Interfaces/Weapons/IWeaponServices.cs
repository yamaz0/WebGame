using WebGame.UI.Blazor.ViewModels.Weapons;

namespace WebGame.UI.Blazor.Interfaces.Weapons
{
    public interface IWeaponServices
    {
        Task<List<WeaponsListBlazorVM>> GetAllWeapons();
    }
}
