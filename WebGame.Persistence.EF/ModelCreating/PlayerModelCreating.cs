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
                eb.Property(x => x.Exp).HasDefaultValue(ConstantsPlayer.DEFAULT_EXP);
                eb.Property(x => x.Level).HasDefaultValue(ConstantsPlayer.DEFAULT_LEVEL);
                eb.Property(x => x.SkillPoints).HasDefaultValue(ConstantsPlayer.DEFAULT_SKILL_POINTS);
                eb.Property(x => x.Cash).HasDefaultValue(ConstantsPlayer.DEFAULT_CASH);
                eb.Property(x => x.Strenght).HasDefaultValue(ConstantsPlayer.DEFAULT_STRENGHT);
                eb.Property(x => x.Dexterity).HasDefaultValue(ConstantsPlayer.DEFAULT_DEXTERITY);
                eb.Property(x => x.Endurance).HasDefaultValue(ConstantsPlayer.DEFAULT_ENDURANCE);
                eb.Property(x => x.JobId).HasDefaultValue(0);
                eb.Property(x => x.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(x => x.CreatedBy).HasDefaultValue("saba");
                eb.Property(x => x.LastModifiedBy).HasDefaultValue("saba");
                eb.Property(x => x.LastModifiedDate).ValueGeneratedOnAddOrUpdate();
            });
        }
    }
}
