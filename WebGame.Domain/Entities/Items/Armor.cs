namespace WebGame.Entities.Items
{
    public enum ItemType { _0, _1, _2, _3 }
    public class Armor : ItemBase
    {
        public int Defense { get; set; }
        public int ItemType { get; set; }
    }
}
