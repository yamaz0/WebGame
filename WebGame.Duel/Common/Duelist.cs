using WebGame.Domain.Common;

namespace WebGame.Duel.Common
{
    public class Duelist : IDuelable
    {
        public string Name { get; set; }
        public int HealthPoint { get; set; }
        public int Defense { get; set; }
        public int Attack { get; set; }

        public Duelist(IDuelable duelableEntity)
        {
            Name = duelableEntity.Name;
            HealthPoint = duelableEntity.HealthPoint;
            Defense = duelableEntity.Defense;
            Attack = duelableEntity.Attack;
        }

        public int AttackOpponent(Duelist opponent)
        {
            return opponent.TakeDamage(Attack);
        }

        public int TakeDamage(int value)
        {
            int damage = Math.Clamp(value - Defense, 1, int.MaxValue);
            HealthPoint -= damage;
            return damage;
        }

        public bool IsAlive()
        {
            return HealthPoint > 0;
        }
    }
}
