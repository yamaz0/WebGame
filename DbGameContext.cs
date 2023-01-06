using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebGame.Entities;
using WebGame.Entities.Enemies;
using WebGame.Entities.Items;
using WebGame.Entities.Jobs;
using WebGame.Entities.Missions;

namespace WebGame
{
    public class DbGameContext : IdentityDbContext
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
            base.OnModelCreating(builder);
        }
    }
}
