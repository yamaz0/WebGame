using WebGame.Entities.Items;

namespace WebGame.Services.Shop.Interfaces
{
    public interface IShopService
    {
        void BuyBodyArmorItem(int itemId);
        void BuyWeaponItem(int itemId);
        IEnumerable<BodyArmor> GetAllBodyArmors();
        IEnumerable<Weapon> GetAllWeapons();
    }
}