using WebGame.Domain.Entities.Player;

namespace WebGame.Application.Functions.Duel.Command
{
    public class DuelViewData
    {
        public Player Player;
        public bool PlayerWin { get; set; }
        public List<string> DuelHistory { get; set; }
        public string Message { get; set; }
        public int RewardCash { get; set; }
        public int RewardExp { get; set; }
    }
}