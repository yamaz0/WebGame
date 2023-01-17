using WebGame.Entities.Jobs;

namespace WebGame.Services.Job.Interface
{
    public interface IJobService
    {
        IEnumerable<Entities.Jobs.Job> GetAllJobs();
        void Job(string userId, int jobId);
    }
}
