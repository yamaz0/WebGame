using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Jobs;

namespace WebGame.Persistence.EF.Repository
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        public JobRepository(DbGameContext context) : base(context)
        {
        }
    }
}