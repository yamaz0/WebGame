using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Items;

namespace WebGame.Persistence.EF.Repository
{
    public class ArmorRepository : BaseRepository<Armor>, IArmorRepository
    {
        public ArmorRepository(DbGameContext context) : base(context)
        {
        }
    }
}