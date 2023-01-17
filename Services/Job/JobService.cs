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

        public void Job(string userId, int jobId)
        {
            var player = _context.Players.ToList().Find(p => p.UserId.Equals(userId));
            var job = _context.Jobs.ToList().Find(j => j.Id.Equals(jobId));

            player.Cash += job.Reward;

            _context.SaveChanges();
        }
    }
}
