using WebGame.Entities.Missions;

namespace WebGame.Persistence.EF.DummyData
{
    public class DummyMissions
    {
        public static List<Mission> Get()
        {
            return new List<Mission>
            {
                new Mission()
                {
                    Id=1,
                    Name = "misja1",
                    Description = "asdasd",
                    Duration= 1,
                    RewardExp= 1
                },
                new Mission()
                {
                    Id=2,
                    Name = "misja2",
                    Description = "hfgghfg",
                    Duration= 2,
                    RewardExp= 2
                }
            };
        }
    }
}