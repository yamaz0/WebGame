using WebGame.UI.Blazor.Interfaces.Armors;
using WebGame.UI.Blazor.Interfaces.Players;
using WebGame.UI.Blazor.Interfaces.Weapons;
using WebGame.UI.Blazor.Services.Armors;
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
            return services;
        }
    }
}
