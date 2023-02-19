using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Items;

namespace WebGame.Persistence.EF.Repository
{
    public class BodyArmorRepository : BaseRepository<BodyArmor>, IBodyArmorRepository
    {
        public BodyArmorRepository(DbGameContext context) : base(context)
        {
        }
    }
}