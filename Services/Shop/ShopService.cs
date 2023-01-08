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
    }
}
