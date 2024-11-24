using System;
using ET.SchoolBus.Pack.AppContext;
using ET.SchoolBus.Pack.TenantContext;
using Microsoft.Extensions.DependencyInjection;

namespace ET.SchoolBus.Pack;

public static class PackServiceRegistration
{
    public static void AddPackServices(this IServiceCollection services)
    {
        services.AddScoped<ApplicationUserContext>();
        services.AddScoped<ITenantManagerContext, TenantManagerContext>();
    }
}
