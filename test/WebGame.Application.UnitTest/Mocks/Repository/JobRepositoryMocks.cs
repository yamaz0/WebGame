using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Items;
using WebGame.Entities.Jobs;

namespace WebGame.Application.UnitTest.Mocks.Repository
{
    public class JobRepositoryMocks
    {
        public static Mock<IJobRepository> GetJobRepository()
        {
            var mockRepository = new Mock<IJobRepository>();

            List<Job> jobs = GetJobs();

            mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(jobs);

            mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
                (int id) =>
                {
                    var job = jobs.FirstOrDefault(x => x.Id.Equals(id));
                    return job;
                });

            mockRepository.Setup(r => r.AddAsync(It.IsAny<Job>())).ReturnsAsync(
                (Job job) =>
                {
                    jobs.Add(job);
                    return job;
                }
                );

            mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Job>()));

            mockRepository.Setup(r => r.RemoveAsync(It.IsAny<Job>()));

            return mockRepository;
        }

        private static List<Job> GetJobs()
        {
            return new List<Job>
            {
                new Job()
                {
                    Id=1,
                    Name = "praca1",
                    Description = "asdasd",
                    Duration= 1,
                    Reward= 1
                },
                new Job()
                {
                    Id=2,
                    Name = "praca2",
                    Description = "hfgghfg",
                    Duration= 3,
                    Reward= 2
                }
            };
        }
    }
}
