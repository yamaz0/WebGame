using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Items;

namespace WebGame.Application.UnitTest.Mocks.Repository
{
    public class ArmorRepositoryMocks
    {
        public static Mock<IArmorRepository> GetArmorRepository()
        {
            var mockRepository = new Mock<IArmorRepository>();

            List<Armor> armors = GetArmors();

            mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(armors);

            mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
                (int id) =>
                {
                    var armor = armors.FirstOrDefault(x => x.Id.Equals(id));
                    return armor;
                });

            mockRepository.Setup(r => r.AddAsync(It.IsAny<Armor>())).ReturnsAsync(
                (Armor armor) =>
                {
                    armors.Add(armor);
                    return armor;
                }
                );

            mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Armor>()))
                .Callback((Armor armor) =>
                {
                    int searchIndex = armors.FindIndex(w => w.Id == armor.Id);
                    armors[searchIndex] = armor;
                });

            mockRepository.Setup(r => r.RemoveAsync(It.IsAny<Armor>()))
                .Callback((Armor armor) =>
                {
                    int searchIndex = armors.FindIndex(w => w.Id == armor.Id);
                    armors.RemoveAt(searchIndex);
                });

            return mockRepository;
        }

        private static List<Armor> GetArmors()
        {
            return new List<Armor>
            {
                new Armor()
                {
                    Id=1,
                    Name = "helmet",
                    Description = "helmet na start",
                    Value = 1,
                    Defense = 1,
                    ItemType = 0
                },
                new Armor()
                {
                    Id=2,
                    Name = "armor",
                    Description = "armor na start",
                    Value = 1,
                    Defense = 1,
                    ItemType = 1
                },
                new Armor()
                {
                    Id=3,
                    Name = "legs",
                    Description = "legi na start",
                    Value = 1,
                    Defense = 1,
                    ItemType = 2
                },
                new Armor()
                {
                    Id=4,
                    Name = "boots",
                    Description = "bootsy na start",
                    Value = 1,
                    Defense = 1,
                    ItemType = 3
                },
                new Armor()
                {
                    Id=5,
                    Name = "Expensive Armor",
                    Description = "drogi oj drogi armor",
                    Value = 99999,
                    Defense = 1,
                    ItemType = 1
                }
            };
        }
    }
}
