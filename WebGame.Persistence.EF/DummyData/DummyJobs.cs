using WebGame.Entities.Jobs;

namespace WebGame.Persistence.EF.DummyData
{
    public class DummyJobs
    {
        public static List<Job> Get()
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