using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Domain.Entities.Player;
using WebGame.Entities.Items;

namespace WebGame.Application.UnitTest.Mocks.Repository
{
    public class PlayerRepositoryMocks
    {
        public static Mock<IPlayerRepository> GetPlayerRepository()
        {
            var mockRepository = new Mock<IPlayerRepository>();

            List<Player> players = GetPlayers();

            mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(players);

            mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
                (int id) =>
                {
                    var player = players.FirstOrDefault(x => x.Id.Equals(id));
                    return player;
                });

            mockRepository.Setup(r => r.AddAsync(It.IsAny<Player>())).ReturnsAsync(
                (Player player) =>
                {
                    players.Add(player);
                    return player;
                }
                );

            mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Player>()))
                .Callback((Player player) =>
                {
                    int searchIndex = players.FindIndex(w => w.Id == player.Id);
                    players[searchIndex] = player;
                });

            mockRepository.Setup(r => r.RemoveAsync(It.IsAny<Player>()))
                .Callback((Player player) =>
                {
                    int searchIndex = players.FindIndex(w => w.Id == player.Id);
                    players.RemoveAt(searchIndex);
                });

            return mockRepository;
        }

        private static List<Player> GetPlayers()
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
                    Endurance = 10,
                    UserId = "user1",
                    ActionId= 1,
                    ActionState = Domain.TimeActionEnum.TimeActionState.Finished,
                    ActionType = Domain.TimeActionEnum.TimeActionType.Mission,
                    EndTime = new DateTime(1999,1,1)
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
                    Endurance = 10,
                    UserId = "user2",
                    ActionId = 1,
                    ActionState = Domain.TimeActionEnum.TimeActionState.InProgress,
                    ActionType = Domain.TimeActionEnum.TimeActionType.Mission,
                    EndTime = new DateTime(9999,1,1)
                },
                new Player()
                {
                    Id=3,
                    Name = "asdasdasdasSASDASD",
                    Level = 10,
                    Exp = 1000,
                    Cash = 100,
                    SkillPoints = 10,
                    Strenght = 10,
                    Dexterity = 10,
                    Endurance = 10,
                    UserId = "user3",
                    ActionId = 0,
                    ActionState = Domain.TimeActionEnum.TimeActionState.NoAction,
                    ActionType = Domain.TimeActionEnum.TimeActionType.Mission,
                    EndTime = new DateTime()
                },
                new Player()
                {
                    Id=4,
                    Name = "asdasdasdasSASDAS242424D",
                    Level = 10,
                    Exp = 1000,
                    Cash = 100,
                    SkillPoints = 10,
                    Strenght = 10,
                    Dexterity = 10,
                    Endurance = 10,
                    UserId = "user4",
                    ActionId = 1,
                    ActionState = Domain.TimeActionEnum.TimeActionState.InProgress,
                    ActionType = Domain.TimeActionEnum.TimeActionType.Work,
                    EndTime = new DateTime(9999,1,1)
                }
            };
        }
    }
}
