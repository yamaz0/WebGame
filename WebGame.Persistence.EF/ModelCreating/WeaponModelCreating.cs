using Microsoft.EntityFrameworkCore;
using WebGame.Entities.Items;

namespace WebGame.Persistence.EF.ModelCreating
{
    public class WeaponModelCreating
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<Weapon>(eb =>
            {
                eb.HasKey(x => x.Id);
                eb.Property(x => x.Name).IsRequired();
                eb.Property(x => x.CreatedDate).HasDefaultValueSql("date('now')");
                eb.Property(x => x.CreatedBy).HasDefaultValue("saba");
                eb.Property(x => x.LastModifiedBy).HasDefaultValue("saba");
                eb.Property(x => x.LastModifiedDate).ValueGeneratedOnAddOrUpdate();
            });
        }
    }
}
