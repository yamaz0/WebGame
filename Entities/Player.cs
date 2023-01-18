using System.ComponentModel.DataAnnotations;
using WebGame.Entities.Items;

namespace WebGame.Entities
{
    public class Player
    {
        [Key]
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
    }

}
