using System.ComponentModel.DataAnnotations;

namespace WebGame.Entities.Enemies
{
    public class Enemy
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int HealthPoint { get; set; }
        public int Attack { get; set; }
    }

}
