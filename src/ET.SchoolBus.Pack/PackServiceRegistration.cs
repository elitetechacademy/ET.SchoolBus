using ET.SchoolBus.Pack.AppContext;
using Microsoft.Extensions.DependencyInjection;

namespace ET.SchoolBus.Pack;

public static class PackServiceRegistration
{
    public static void AddPackServices(this IServiceCollection services)
    {
        services.AddScoped<ApplicationUserContext>();
    }
}
