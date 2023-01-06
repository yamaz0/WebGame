using System.ComponentModel.DataAnnotations;

namespace WebGame.Entities.Items
{
    public class ItemBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
