using WebGame;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Items;

namespace WebGame.Persistence.EF.Repository
{
    public class WeaponRepository : BaseRepository<Weapon>, IWeaponRepository
    {
        public WeaponRepository(DbGameContext context) : base(context)
        {
        }
    }
}