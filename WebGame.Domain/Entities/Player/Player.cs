using System.ComponentModel.DataAnnotations;
using System.Numerics;
using WebGame.Domain.Common;
using WebGame.Entities.Items;

namespace WebGame.Domain.Entities.Player
{
    public class Player : AuditableEntity, IDuelable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        #region level
        public int Level { get; set; } = 1;
        public int Exp { get; set; }
        #endregion

        #region Cash
        public int Cash { get; set; }
        #endregion

        #region Statistics
        public int SkillPoints { get; set; }
        public int Strenght { get; set; } = 10;
        public int Dexterity { get; set; } = 10;
        public int Endurance { get; set; } = 10;
        public int HealthPoint { get; set; }
        public int Defense { get; set; }
        public int Attack { get; set; }
        public int AttackSpeed { get; set; }
        #endregion

        #region Armors
        public virtual BodyArmor? Helmet { get; set; }
        public virtual BodyArmor? Armor { get; set; }
        public virtual BodyArmor? Legs { get; set; }
        public virtual BodyArmor? Boots { get; set; }
        public virtual Weapon? Weapon { get; set; }
        #endregion

        #region User
        public string UserId { get; set; }
        #endregion

        #region Job

        public int JobId { get; set; }
        public DateTime EndJobTime { get; set; }

        #endregion

        #region Mission

        public int MissionId { get; set; }
        public int Stamina { get; set; }
        public DateTime EndMissionTime { get; set; }

        #endregion

        public void SetDefense()
        {
            HealthPoint = Helmet.Defense + Armor.Defense + Legs.Defense + Boots.Defense;
        }

        public void SetHealthPoint()
        {
            Defense = Endurance * 10;
        }
        public void SetAttack()
        {
            Attack = Weapon.Attack * Strenght;
        }

        public void SetAttackSpeed()
        {
            AttackSpeed = Weapon.AttackSpeed * Dexterity;
        }
    }

}
