using WebGame.Domain.Common;

namespace WebGame.Application.Functions.Duel.Query
{
    public class Duelist: IDuelable
    {
        public int HealthPoint { get; set; }
        public int Defense { get; set; }
        public int Attack { get; set; }
        public int AttackSpeed { get; set; }

        public Duelist(IDuelable duelableEntity)
        {
            HealthPoint = duelableEntity.HealthPoint;
            Defense = duelableEntity.Defense;
            Attack = duelableEntity.Attack;
            AttackSpeed = duelableEntity.AttackSpeed;
        }

        public int AttackOpponent(Duelist opponent)
        {
            return opponent.TakeDamage(Attack);
        }

        public int TakeDamage(int value)
        {
            int damage = value - Defense;
            HealthPoint -= damage;
            return damage;
        }

        public bool IsAlive()
        {
            return HealthPoint > 0;
        }
    }
}
