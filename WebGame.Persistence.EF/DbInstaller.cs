using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebGame.Application.Interfaces.Duel;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Duel;
using WebGame.Persistence.EF.Repository;

namespace WebGame
{
    public static class DbInstaller
    {
        public static IServiceCollection InstallDb(this IServiceCollection services)
        {
            services.AddDbContext<DbGameContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IEnemyRepository, EnemyRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IMissionRepository, MissionRepository>();
            services.AddScoped<IArmorRepository, ArmorRepository>();
            services.AddScoped<IWeaponRepository, WeaponRepository>();

            services.AddScoped<IDuel, DuelPlayerVsEnemy>();

            return services;
        }
    }
}
