using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebGame.Entities.Items;

namespace WebGame.Persistence.EF.ModelCreating
{
    public class ArmorModelCreating
    {
        public static void Configure(ModelBuilder builder)
        {
            var converter = new EnumToStringConverter<ItemType>();

            builder.Entity<Armor>()
                .Property(e => e.ItemType)
                .HasConversion(converter);

            builder.Entity<Armor>(eb =>
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
