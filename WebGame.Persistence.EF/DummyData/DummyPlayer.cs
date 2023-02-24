using WebGame.Domain.Entities.Player;

namespace WebGame.Persistence.EF.DummyData
{
    public class DummyPlayer
    {
        public static List<Player> Get()
        {
            return new List<Player>
            {
                new Player()
                {
                    Id=1,
                    Name = "Graczek",
                    Level = 10,
                    Exp = 1000,
                    Cash = 100,
                    SkillPoints = 10,
                    Strenght = 10,
                    Dexterity = 10,
                    Endurance= 10,
                    UserId = "user1"
                },
                new Player()
                {
                    Id=2,
                    Name = "asdasdasdas",
                    Level = 10,
                    Exp = 1000,
                    Cash = 100,
                    SkillPoints = 10,
                    Strenght = 10,
                    Dexterity = 10,
                    Endurance= 10,
                    UserId = "user2"
                }
            };
        }
    }
}