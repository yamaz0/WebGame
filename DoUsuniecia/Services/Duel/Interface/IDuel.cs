using WebGame.Models;

namespace WebGame.Services.Duel.Interface
{
    public interface IDuel
    {
        public bool Fight();
        public DuelData Details { get; set; }
    }
}
