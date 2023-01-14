using WebGame.Entities.Items;
using WebGame.Services.Player.Interface;
using WebGame.Services.Shop.Interfaces;

namespace WebGame.Services.Shop
{
    public class ShopService : IShopService
    {
        private readonly DbGameContext _context;

        public ShopService(DbGameContext context)
        {
            _context = context;
        }

        public IEnumerable<BodyArmor> GetAllBodyArmors()
        {
            return _context.BodyArmors.ToList();
        }

        public IEnumerable<Weapon> GetAllWeapons()
        {
            return _context.Weapons.ToList();
        }
        public void BuyBodyArmorItem(int itemId)
        {
            var item = _context.BodyArmors.ToList().Find(i => i.Id.Equals(itemId));
            var player = _context.Players.ToList().FirstOrDefault();
            switch (item.ItemType)
            {
                case ItemType.HELMET:
                    player.Helmet = item;
                    break;
                case ItemType.ARMOR:
                    player.Armor = item;
                    break;
                case ItemType.LEGS:
                    player.Legs = item;
                    break;
                case ItemType.BOOTS:
                    player.Boots = item;
                    break;
                default:
                    break;
            }
            _context.SaveChanges();
        }
        public void BuyWeaponItem(int itemId)
        {
            var item = _context.Weapons.ToList().Find(i => i.Id.Equals(itemId));
            var player = _context.Players.ToList().FirstOrDefault();
            player.Weapon = item;

            _context.SaveChanges();
        }
    }
}
