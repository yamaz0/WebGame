namespace WebGame.UI.Blazor.ViewModels.Missions
{
    public class MissionBlazorVM
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Reward { get; set; }
    }    
}