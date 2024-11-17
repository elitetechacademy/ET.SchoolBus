using ET.SchoolBus.Integration.Implementations;
using ET.SchoolBus.Integration.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ET.SchoolBus.Application;

public static class ApplicationServiceRegistration
{
    public static void AddIntegrationServices(this IServiceCollection services)
    {
        services.AddScoped<ICypherService, CypherService>();
    }
}
