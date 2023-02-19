using System.ComponentModel.DataAnnotations;

namespace WebGame.Entities.Jobs
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Reward { get; set; }
    }

}
