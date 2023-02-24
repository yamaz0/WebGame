using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Entities.Items;

namespace WebGame.Persistence.EF.DummyData
{
    public class DummyWeapons
    {
        public static List<Weapon> Get()
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