using Microsoft.Extensions.DependencyInjection;
using WebGame.Application.Interfaces.TimeAction;

namespace WebGame.TimeAction
{
    static public class TimeActionInstaller
    {
        public static IServiceCollection InstallTimeAction(this IServiceCollection services)
        {
            return services.AddScoped<ITimeActionService, TimeActionService>();
        }
    }
}