using Microsoft.EntityFrameworkCore;
using WebGame.Entities.Jobs;

namespace WebGame.Persistence.EF.ModelCreating
{
    public class JobModelCreating
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<Job>(eb =>
            {
                eb.HasKey(x => x.Id);
                eb.Property(x => x.Name).IsRequired();
                eb.Property(x => x.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(x => x.CreatedBy).HasDefaultValue("saba");
                eb.Property(x => x.LastModifiedBy).HasDefaultValue("saba");
                eb.Property(x => x.LastModifiedDate).ValueGeneratedOnAddOrUpdate();
            });
        }
    }
}
