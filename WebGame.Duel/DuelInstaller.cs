using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Interfaces.Duel;

namespace WebGame.Duel
{
    public static class DuelInstaller
    {
        public static IServiceCollection InstallDuel(this IServiceCollection services)
        {
            return services.AddScoped<IDuel, DuelPlayerVsEnemy>();
        }
    }
}
