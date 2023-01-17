using WebGame.Entities.Items;

namespace WebGame.Services.Shop.Interfaces
{
    public interface IShopService
    {
        void BuyBodyArmorItem(string userId, int itemId);
        void BuyWeaponItem(string userId, int itemId);
        IEnumerable<BodyArmor> GetAllBodyArmors();
        IEnumerable<Weapon> GetAllWeapons();
    }
}