using WebGame.Application.Interfaces.Persistence.Common;
using WebGame.Entities.Items;

namespace WebGame.Application.Interfaces.Persistence
{
    public interface IWeaponRepository : IAsyncRepository<Weapon>
    {
    }
}
