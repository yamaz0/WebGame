namespace WebGame.Domain.Common
{
    public interface ITimeAction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int RewardExp { get; set; }
        public int RewardCash { get; set; }
    }
}