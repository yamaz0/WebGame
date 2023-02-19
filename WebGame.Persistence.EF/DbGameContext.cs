using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection.Emit;
using WebGame.Entities;
using WebGame.Entities.Enemies;
using WebGame.Entities.Items;
using WebGame.Entities.Jobs;
using WebGame.Entities.Missions;

namespace WebGame
{
    public class DbGameContext : IdentityDbContext<UserEntity>
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<BodyArmor> BodyArmors { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Mission> Missions { get; set; }

        public DbGameContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var converter = new EnumToStringConverter<ItemType>();

            builder.Entity<BodyArmor>()
                .Property(e => e.ItemType)
                .HasConversion(converter);

            builder.Entity<Player>(eb =>
            {
                eb.Property(x => x.Name).IsRequired();
                eb.Property(x => x.Exp).HasDefaultValue(0);
                eb.Property(x => x.Level).HasDefaultValue(1);
                eb.Property(x => x.SkillPoints).HasDefaultValue(0);
                eb.Property(x => x.Cash).HasDefaultValue(0);
                eb.Property(x => x.Strenght).HasDefaultValue(10);
                eb.Property(x => x.Dexterity).HasDefaultValue(10);
                eb.Property(x => x.Endurance).HasDefaultValue(10);
                eb.Property(x => x.JobId).HasDefaultValue(0);
            });

            base.OnModelCreating(builder);
        }
    }
}
