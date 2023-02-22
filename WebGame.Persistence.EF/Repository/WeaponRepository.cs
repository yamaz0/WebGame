using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<List<Weapon>> GetPagedWeaponsAsync(int page, int pageSize)
        {
            int skipElementsNumber = (page - 1) * pageSize;
            return await _context.Weapons.Skip(skipElementsNumber).Take(pageSize).AsNoTracking().ToListAsync();
        }
    }
}