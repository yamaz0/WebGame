﻿using System.ComponentModel.DataAnnotations;
using System.Numerics;
using WebGame.Domain.Common;
using WebGame.Domain.TimeActionEnum;
using WebGame.Entities.Items;

namespace WebGame.Domain.Entities.Player
{
    public class Player : AuditableEntity, IDuelable
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
        public int HealthPoint { get; set; }
        public int Defense { get; set; }
        public int Attack { get; set; }
        #endregion

        #region Armors
        public virtual Armor? Helmet { get; set; }
        public virtual Armor? Armor { get; set; }
        public virtual Armor? Legs { get; set; }
        public virtual Armor? Boots { get; set; }
        public virtual Weapon? Weapon { get; set; }
        #endregion

        #region User
        public string UserId { get; set; }
        #endregion

        #region TimeAction

        public TimeActionType ActionType { get; set; }
        public TimeActionState ActionState { get; set; }
        public int ActionId { get; set; }
        public int Duration { get; set; }
        public DateTime EndTime { get; set; }

        #endregion

        #region Mission

        public int Stamina { get; set; }

        #endregion

        public void AddReward(int exp, int cash)
        {
            int expRequirement = Utils.CalculateExpRequirement(Level);

            Exp += exp;
            Cash += cash;

            while (Exp >= expRequirement)
            {
                Exp -= expRequirement;
                Level++;
                SkillPoints++;
                expRequirement = Utils.CalculateExpRequirement(Level);
            }
        }

        public void AddStrenght()
        {
            Strenght++;
            SkillPoints--;
            UpdateAttack();
        }

        public void AddDexterity()
        {
            Dexterity++;
            SkillPoints--;
        }

        public void AddEndurance()
        {
            Endurance++;
            SkillPoints--;
            UpdateHealthPoint();
        }

        public void UpdateDefense()
        {
            int helmetDefense = Helmet is not null ? Helmet.Defense : 0;
            int armorDefense = Armor is not null ? Armor.Defense : 0;
            int legsDefense = Legs is not null ? Legs.Defense : 0;
            int bootsDefense = Boots is not null ? Boots.Defense : 0;

            Defense = helmetDefense + armorDefense + legsDefense + bootsDefense;
        }

        public void UpdateHealthPoint()
        {
            HealthPoint = Endurance * 10;
        }

        public void UpdateAttack()
        {
            int weaponAttack = Weapon is not null ? Weapon.Attack : 1;
            Attack = weaponAttack * Strenght;
        }

        public void SetArmor(Armor armor)
        {
            switch (armor.ItemType)
            {
                case 0:
                    Helmet = armor;
                    break;
                case 1:
                    Armor = armor;
                    break;
                case 2:
                    Legs = armor;
                    break;
                case 3:
                    Boots = armor;
                    break;
            };
            UpdateDefense();
        }

        public void SetWeapon(Weapon weapon)
        {
            Weapon = weapon;
            UpdateAttack();
        }
    }
}