using System.Data;
using System.Drawing;
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
            var player = GetPlayer(userId);
            var job = _context.Jobs.ToList().Find(j => j.Id.Equals(jobId));

            player.JobId = jobId;
            player.EndJobTime = DateTime.Now.AddMinutes(job.Duration);

            _context.SaveChanges();
        }

        public bool HasWork(string userId)
        {
            Entities.Player? player = GetPlayer(userId);
            return player.JobId != 0;
        }

        public string TryReward(string userId)
        {
            Entities.Player? player = GetPlayer(userId);

            if (player.EndJobTime <= DateTime.Now)
            {
                var job = _context.Jobs.ToList().Find(j => j.Id.Equals(player.JobId));

                Reward(player, job);
                return $"Reward: {job.Reward} cash";
            }

            return $"Job end: {player.EndJobTime.ToString()}";
        }

        private void Reward(Entities.Player player, Entities.Jobs.Job job)
        {
            player.Cash += job.Reward;
            ResetJob(player);

            _context.SaveChanges();
        }

        private static void ResetJob(Entities.Player player)
        {
            player.JobId = 0;
        }

        private Entities.Player? GetPlayer(string userId)
        {
            return _context.Players.ToList().Find(p => p.UserId.Equals(userId));
        }
    }
}
