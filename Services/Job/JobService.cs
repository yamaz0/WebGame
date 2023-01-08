using WebGame.Services.Job.Interface;

namespace WebGame.Services.Job
{
    public class JobService : IJobService
    {
        private readonly DbGameContext _context;

        public JobService(DbGameContext context)
        {
            _context = context;
        }
        public IEnumerable<Entities.Jobs.Job> GetAllJobs()
        {
            return _context.Jobs.ToList();
        }
    }
}
