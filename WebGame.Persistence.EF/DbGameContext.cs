using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection.Emit;
using WebGame.Application.Constants;
using WebGame.Domain.Common;
using WebGame.Domain.Entities.Player;
using WebGame.Domain.Entities.User;
using WebGame.Entities;
using WebGame.Entities.Enemies;
using WebGame.Entities.Items;
using WebGame.Entities.Jobs;
using WebGame.Entities.Missions;
using WebGame.Persistence.EF.DummyData;

namespace WebGame
{
    public class DbGameContext : IdentityDbContext<UserEntity>
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Mission> Missions { get; set; }

        public DbGameContext(DbContextOptions options) : base(options) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DbGameContext).Assembly);

            var converter = new EnumToStringConverter<ItemType>();

            builder.Entity<Armor>()
                .Property(e => e.ItemType)
                .HasConversion(converter);

            builder.Entity<Player>(eb =>
            {
                eb.Property(x => x.Name).IsRequired();
                eb.Property(x => x.Exp).HasDefaultValue(ConstantsPlayer.DEFAULT_EXP);
                eb.Property(x => x.Level).HasDefaultValue(ConstantsPlayer.DEFAULT_LEVEL);
                eb.Property(x => x.SkillPoints).HasDefaultValue(ConstantsPlayer.DEFAULT_SKILL_POINTS);
                eb.Property(x => x.Cash).HasDefaultValue(ConstantsPlayer.DEFAULT_CASH);
                eb.Property(x => x.Strenght).HasDefaultValue(ConstantsPlayer.DEFAULT_STRENGHT);
                eb.Property(x => x.Dexterity).HasDefaultValue(ConstantsPlayer.DEFAULT_DEXTERITY);
                eb.Property(x => x.Endurance).HasDefaultValue(ConstantsPlayer.DEFAULT_ENDURANCE);
                eb.Property(x => x.JobId).HasDefaultValue(0);
            });

            builder.Entity<AuditableEntity>(ae =>
            {
                ae.Property(x => x.CreatedDate).HasDefaultValueSql("getutcdate()");
                ae.Property(x => x.CreatedBy).HasDefaultValue("saba");
                ae.Property(x => x.LastModifiedBy).HasDefaultValue("saba");
                ae.Property(x => x.LastModifiedDate).ValueGeneratedOnAddOrUpdate();
            });

            FillDummyData(builder);
            base.OnModelCreating(builder);
        }

        private void FillDummyData(ModelBuilder builder)
        {
            foreach (var item in DummyEnemies.Get())
            {
                builder.Entity<Enemy>().HasData(item);
            }
            foreach (var item in DummyArmor.Get())
            {
                builder.Entity<Armor>().HasData(item);
            }
            foreach (var item in DummyWeapons.Get())
            {
                builder.Entity<Weapon>().HasData(item);
            }
            foreach (var item in DummyPlayer.Get())
            {
                builder.Entity<Player>().HasData(item);
            }
            foreach (var item in DummyJobs.Get())
            {
                builder.Entity<Job>().HasData(item);
            }
            foreach (var item in DummyMissions.Get())
            {
                builder.Entity<Mission>().HasData(item);
            }
        }
    }
}
