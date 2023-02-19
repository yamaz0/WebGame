using System.ComponentModel.DataAnnotations;
using WebGame.Domain.Common;

namespace WebGame.Entities.Enemies
{
    public class Enemy : AuditableEntity, IDuelable
    {
        public string Name { get; set; }
        public int HealthPoint { get; set; }
        public int Defense { get; set; }
        public int AttackSpeed { get; set; }
        public int Attack { get; set; }
        public int ExpReward { get; set; }
        public int CashReward { get; set; }
    }

}
