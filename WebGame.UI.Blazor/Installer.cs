using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Radzen;
using WebGame.UI.Blazor.Interfaces.Arena;
using WebGame.UI.Blazor.Interfaces.Armors;
using WebGame.UI.Blazor.Interfaces.Authorization;
using WebGame.UI.Blazor.Interfaces.Enemies;
using WebGame.UI.Blazor.Interfaces.Jobs;
using WebGame.UI.Blazor.Interfaces.Missions;
using WebGame.UI.Blazor.Interfaces.Players;
using WebGame.UI.Blazor.Interfaces.Weapons;
using WebGame.UI.Blazor.Services.Arena;
using WebGame.UI.Blazor.Services.Armors;
using WebGame.UI.Blazor.Services.Authentication;
using WebGame.UI.Blazor.Services.Enemies;
using WebGame.UI.Blazor.Services.Missions;
using WebGame.UI.Blazor.Services.Players;
using WebGame.UI.Blazor.Services.Weapons;

namespace WebGame.UI.Blazor
{
    public static class Installer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IArmorServices, ArmorServices>();
            services.AddScoped<IWeaponServices, WeaponServices>();
            services.AddScoped<IPlayerServices, PlayerServices>();
            services.AddScoped<IMissionServices, MissionServices>();
            services.AddScoped<IJobServices, JobServices>();
            services.AddScoped<IArenaEnemyService, ArenaEnemyService>();
            services.AddScoped<IEnemiesService, EnemiesService>();
            services.AddScoped<IAddBearerTokenService, AddBearerTokenService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddAuthorizationCore();

            RadzenStuff(services);

            return services;
        }

        private static void RadzenStuff(IServiceCollection services)
        {
            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();
        }
    }
}
