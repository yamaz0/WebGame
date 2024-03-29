﻿using WebGame.Entities.Items;

namespace WebGame.Persistence.EF.DummyData
{
    public class DummyArmor
    {
        public static List<Armor> Get()
        {
            return new List<Armor>
            {
                new Armor()
                {
                    Id=1,
                    Name = "leather helmet",
                    Description = "helmet na start",
                    Value = 1,
                    Defense = 1,
                    ItemType = 0
                },
                new Armor()
                {
                    Id=2,
                    Name = "leather armor",
                    Description = "armor na start",
                    Value = 1,
                    Defense = 1,
                    ItemType = 1
                },
                new Armor()
                {
                    Id=3,
                    Name = "leather legs",
                    Description = "legi na start",
                    Value = 1,
                    Defense = 1,
                    ItemType = 2
                },
                new Armor()
                {
                    Id=4,
                    Name = "leather boots",
                    Description = "bootsy na start",
                    Value = 1,
                    Defense = 1,
                    ItemType = 3
                },
                new Armor()
                {
                    Id=5,
                    Name = "golden helmet",
                    Description = "helmet",
                    Value = 100,
                    Defense = 100,
                    ItemType = 0
                },
                new Armor()
                {
                    Id=6,
                    Name = "magic plate armor",
                    Description = "armor",
                    Value = 100,
                    Defense = 100,
                    ItemType = 1
                },
                new Armor()
                {
                    Id=7,
                    Name = "dragon scale legs",
                    Description = "legi",
                    Value = 100,
                    Defense = 100,
                    ItemType = 2
                },
                new Armor()
                {
                    Id=8,
                    Name = "golden boots",
                    Description = "bootsy",
                    Value = 100,
                    Defense = 100,
                    ItemType = 3
                }
            };
        }
    }
}