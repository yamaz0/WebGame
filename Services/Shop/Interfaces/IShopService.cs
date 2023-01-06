using WebGame.Entities.Items;

namespace WebGame.Services.Shop.Interfaces
{
    public interface IShopService
    {
        IEnumerable<BodyArmor> GetAllBodyArmors();
        IEnumerable<Weapon> GetAllWeapons();
    }
}