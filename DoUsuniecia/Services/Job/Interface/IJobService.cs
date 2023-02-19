using WebGame.Entities.Jobs;

namespace WebGame.Services.Job.Interface
{
    public interface IJobService
    {
        IEnumerable<Entities.Jobs.Job> GetAllJobs();
        bool HasWork(string userId);
        void Job(string userId, int jobId);
        string TryReward(string userId);
    }
}
