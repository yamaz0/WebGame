namespace WebGame.Models
{
    //public enum DuelResult { DRAW, WIN, LOSE }
    public class DuelData
    {
        public string Result { get; set; } = "DRAW";
        public List<string> DuelHistory { get; set; }
        public DuelData()
        {
            DuelHistory= new List<string>();
        }
    }
}
