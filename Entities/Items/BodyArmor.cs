namespace WebGame.Entities.Items
{
    public enum ItemType { HELMET, ARMOR, LEGS, BOOTS }
    public class BodyArmor : ItemBase
    {
        public int Defense { get; set; }
        public ItemType ItemType { get; set; }
    }
}
