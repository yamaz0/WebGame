using WebGame.Entities.Items;

namespace WebGame.Application.Functions.Players.Query.GetPlayer
{
    public class GetPlayerViewModel
    {
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
        public virtual Armor? Helmet { get; set; }
        public virtual Armor? Armor { get; set; }
        public virtual Armor? Legs { get; set; }
        public virtual Armor? Boots { get; set; }
        public virtual Weapon? Weapon { get; set; }
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
    }
    }
