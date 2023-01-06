using System.ComponentModel.DataAnnotations;

namespace WebGame.Entities.Missions
{
    public class Mission
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Reward { get; set; }
    }

}
