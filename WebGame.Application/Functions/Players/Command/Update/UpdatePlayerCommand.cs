using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Entities.Items;

namespace WebGame.Application.Functions.Players.Command.Update
{
    public class UpdatePlayerCommand : IRequest
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

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
        #endregion

        #region Armors
        //public virtual Armor? Helmet { get; set; }
        //public virtual Armor? Armor { get; set; }
        //public virtual Armor? Legs { get; set; }
        //public virtual Armor? Boots { get; set; }
        //public virtual Weapon? Weapon { get; set; }
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
    }
}
