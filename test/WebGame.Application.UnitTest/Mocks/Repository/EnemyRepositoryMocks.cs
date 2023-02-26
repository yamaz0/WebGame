using Moq;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Enemies;
using WebGame.Entities.Items;

namespace WebGame.Application.UnitTest.Mocks.Repository
{
    public class EnemyRepositoryMocks
    {
        public static Mock<IEnemyRepository> GetEnemyRepository()
        {
            var mockRepository = new Mock<IEnemyRepository>();

            List<Enemy> enemies = GetEnemies();

            mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(enemies);

            mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
                (int id) =>
                {
                    var enemy = enemies.FirstOrDefault(x => x.Id.Equals(id));
                    return enemy;
                });

            mockRepository.Setup(r => r.AddAsync(It.IsAny<Enemy>())).ReturnsAsync(
                (Enemy enemy) =>
                {
                    enemies.Add(enemy);
                    return enemy;
                }
                );

            mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Enemy>()));

            mockRepository.Setup(r => r.RemoveAsync(It.IsAny<Enemy>()));

            return mockRepository;
        }

        private static List<Enemy> GetEnemies()
        {
            return new List<Enemy>
            {
                new Enemy()
                {
                    Id= 1,
                    Name = "enem1",
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
                    Name = "e2",
                    Attack = 555,
                    AttackSpeed = 55,
                    CashReward= 55,
                    ExpReward= 55,
                    HealthPoint= 55,
                    Defense = 55
                }
            };
        }
    }
}
