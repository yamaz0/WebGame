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
    public class WeaponRepositoryMocks
    {
        public static Mock<IWeaponRepository> GetWeaponRepository()
        {
            var mockRepository = new Mock<IWeaponRepository>();

            List<Weapon> weapons = GetWeapons();

            mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(weapons);

            mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
                (int id) =>
                {
                    var weapon = weapons.FirstOrDefault(x => x.Id.Equals(id));
                    return weapon;
                });

            mockRepository.Setup(r => r.AddAsync(It.IsAny<Weapon>())).ReturnsAsync(
                (Weapon weapon) =>
                {
                    weapons.Add(weapon);
                    return weapon;
                }
                );

            mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Weapon>()))
                .Callback((Weapon weapon) =>
            {
                int searchIndex = weapons.FindIndex(w => w.Id == weapon.Id);
                weapons[searchIndex] = weapon;
            });

            mockRepository.Setup(r => r.RemoveAsync(It.IsAny<Weapon>()))
                .Callback((Weapon weapon) =>
            {
                int searchIndex = weapons.FindIndex(w => w.Id == weapon.Id);
                weapons.RemoveAt(searchIndex);
            });

            mockRepository.Setup(r => r.GetPagedWeaponsAsync(It.IsIn<int>(), It.IsIn<int>())).ReturnsAsync(
                (int page, int pageSize) =>
                {
                    return weapons.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                });

            return mockRepository;
        }

        private static List<Weapon> GetWeapons()
        {
            return new List<Weapon>
            {
                new Weapon()
                {
                    Id=1,
                    Name = "mieczyk",
                    Description = "mieczyk na start",
                    Value = 1,
                    Attack = 1,
                    AttackSpeed = 1
                },
                new Weapon()
                {
                    Id=2,
                    Name = "lepszy mieczyk",
                    Description = "mieczyk na potem",
                    Value = 2,
                    Attack = 2,
                    AttackSpeed = 2
                }
            };
        }
    }
}