

using WebGame.UI.Blazor.Services;

namespace WebGame.UI.Blazor.ViewModels.Armors
{
    public class ArmorsListBlazorVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public int Defense { get; set; }
        public ItemType ItemType { get; set; }
    }
}
