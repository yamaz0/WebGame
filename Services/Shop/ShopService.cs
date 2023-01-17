using Microsoft.EntityFrameworkCore;
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
            return _context.BodyArmors.AsNoTracking().ToList();
        }

        public IEnumerable<Weapon> GetAllWeapons()
        {
            return _context.Weapons.AsNoTracking().ToList();
        }
        public void BuyBodyArmorItem(string userId, int itemId)
        {
            var item = _context.BodyArmors.ToList().Find(i => i.Id.Equals(itemId));
            var player = _context.Players.ToList().Find(p => p.UserId.Equals(userId));
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
        public void BuyWeaponItem(string userId, int itemId)
        {
            var item = _context.Weapons.ToList().Find(i => i.Id.Equals(itemId));
            var player = _context.Players.ToList().Find(p => p.UserId.Equals(userId));
            player.Weapon = item;

            _context.SaveChanges();
        }
    }
}
