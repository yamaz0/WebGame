using WebGame.Application.Interfaces.Persistence.Common;
using WebGame.Entities.Items;

namespace WebGame.Application.Interfaces.Persistence
{
    public interface IWeaponRepository : IAsyncRepository<Weapon>
    {
        Task<List<Weapon>> GetPagedWeaponsAsync(int page, int pageSize);
    }
}
