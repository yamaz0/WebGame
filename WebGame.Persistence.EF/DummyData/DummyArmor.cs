using WebGame.Entities.Items;

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
                    Name = "helmet",
                    Description = "helmet na start",
                    Value = 1,
                    Defense = 1,
                    ItemType = ItemType.HELMET
                },
                new Armor()
                {
                    Id=2,
                    Name = "armor",
                    Description = "armor na start",
                    Value = 1,
                    Defense = 1,
                    ItemType = ItemType.ARMOR
                },
                new Armor()
                {
                    Id=3,
                    Name = "legs",
                    Description = "legi na start",
                    Value = 1,
                    Defense = 1,
                    ItemType = ItemType.LEGS
                },
                new Armor()
                {
                    Id=4,
                    Name = "boots",
                    Description = "bootsy na start",
                    Value = 1,
                    Defense = 1,
                    ItemType = ItemType.BOOTS
                }
            };
        }
    }
}