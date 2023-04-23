using WebGame.Entities.Enemies;

namespace WebGame.Persistence.EF.DummyData
{
    public class DummyEnemies
    {
        public static List<Enemy> Get()
        {
            return new List<Enemy>
            {
                new Enemy()
                {
                    Id= 1,
                    Name = "slaby",
                    Attack = 1,
                    AttackSpeed = 1,
                    CashReward= 1,
                    ExpReward= 1,
                    HealthPoint= 1,
                    Defense = 1
                },
                new Enemy()
                {
                    Id=2,
                    Name = "silny",
                    Attack = 555,
                    AttackSpeed = 55,
                    CashReward= 55,
                    ExpReward= 55,
                    HealthPoint= 55,
                    Defense = 55
                },
                new Enemy()
                {
                    Id=3,
                    Name = "duzo exp",
                    Attack = 1,
                    AttackSpeed = 1,
                    CashReward= 100,
                    ExpReward= 100,
                    HealthPoint= 1,
                    Defense = 1
                }
            };
        }
    }
}