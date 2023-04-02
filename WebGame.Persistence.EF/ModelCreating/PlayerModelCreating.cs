using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Constants;
using WebGame.Domain.Entities.Player;

namespace WebGame.Persistence.EF.ModelCreating
{
    public class PlayerModelCreating
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<Player>(eb =>
            {
                eb.HasKey(x => x.Id);
                eb.Property(x => x.Name).IsRequired();
                eb.Property(x => x.Exp).HasDefaultValue(ConstantsEntity.Player.DEFAULT_EXP);
                eb.Property(x => x.Level).HasDefaultValue(ConstantsEntity.Player.DEFAULT_LEVEL);
                eb.Property(x => x.SkillPoints).HasDefaultValue(ConstantsEntity.Player.DEFAULT_SKILL_POINTS);
                eb.Property(x => x.Cash).HasDefaultValue(ConstantsEntity.Player.DEFAULT_CASH);
                eb.Property(x => x.Strenght).HasDefaultValue(ConstantsEntity.Player.DEFAULT_STRENGHT);
                eb.Property(x => x.Dexterity).HasDefaultValue(ConstantsEntity.Player.DEFAULT_DEXTERITY);
                eb.Property(x => x.Endurance).HasDefaultValue(ConstantsEntity.Player.DEFAULT_ENDURANCE);
                eb.Property(x => x.HealthPoint).HasDefaultValue(ConstantsEntity.Player.DEFAULT_HEALTH_POINTS);
                eb.Property(x => x.Attack).HasDefaultValue(ConstantsEntity.Player.DEFAULT_ATTACK);
                eb.Property(x => x.ActionId).HasDefaultValue(0);
                eb.Property(x => x.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(x => x.CreatedBy).HasDefaultValue("saba");
                eb.Property(x => x.LastModifiedBy).HasDefaultValue("saba");
                eb.Property(x => x.LastModifiedDate).ValueGeneratedOnAddOrUpdate();
            });
        }
    }
}
