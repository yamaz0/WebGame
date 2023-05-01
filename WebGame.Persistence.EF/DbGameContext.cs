using Microsoft.AspNetCore.Identity;
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
using WebGame.Entities.Missions;
using WebGame.Persistence.EF.DummyData;
using WebGame.Persistence.EF.ModelCreating;

namespace WebGame
{
    public class DbGameContext : IdentityDbContext<UserEntity>
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Mission> Missions { get; set; }

        public DbGameContext(DbContextOptions options) : base(options) { /*Database.EnsureCreated();*/ }

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

            PlayerModelCreating.Configure(builder);
            EnemyModelCreating.Configure(builder);
            MissionModelCreating.Configure(builder);
            WeaponModelCreating.Configure(builder);
            ArmorModelCreating.Configure(builder);
            FillDummyData(builder);
            base.OnModelCreating(builder);
        }

        private void FillDummyData(ModelBuilder builder)
        {
            foreach (var item in DummyRoles.Get())
            {
                builder.Entity<IdentityRole>().HasData(item);
            }
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
            foreach (var item in DummyMissions.Get())
            {
                builder.Entity<Mission>().HasData(item);
            }
        }
    }
}