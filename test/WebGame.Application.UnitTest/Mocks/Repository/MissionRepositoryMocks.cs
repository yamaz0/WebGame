using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Missions;

namespace WebGame.Application.UnitTest.Mocks.Repository
{
    public class MissionRepositoryMocks
    {
        public static Mock<IMissionRepository> GetMissionRepository()
        {
            var mockRepository = new Mock<IMissionRepository>();

            List<Mission> missions = GetMissions();

            mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(missions);

            mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
                (int id) =>
                {
                    var mission = missions.FirstOrDefault(x => x.Id.Equals(id));
                    return mission;
                });

            mockRepository.Setup(r => r.AddAsync(It.IsAny<Mission>())).ReturnsAsync(
                (Mission mission) =>
                {
                    missions.Add(mission);
                    return mission;
                }
                );

            mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Mission>()));

            mockRepository.Setup(r => r.RemoveAsync(It.IsAny<Mission>()));

            return mockRepository;
        }

        private static List<Mission> GetMissions()
        {
            return new List<Mission>
            {
                new Mission()
                {
                    Id=1,
                    Name = "misja1",
                    Description = "asdasd",
                    Duration= 1,
                    Reward= 1
                },
                new Mission()
                {
                    Id=2,
                    Name = "misja2",
                    Description = "hfgghfg",
                    Duration= 2,
                    Reward= 2
                }
            };
        }
    }
}
