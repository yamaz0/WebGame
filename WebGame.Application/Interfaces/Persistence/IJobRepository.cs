using WebGame.Application.Interfaces.Persistence.Common;
using WebGame.Entities.Jobs;

namespace WebGame.Application.Interfaces.Persistence
{
    public interface IJobRepository : IAsyncRepository<Job>
    {
    }
}
