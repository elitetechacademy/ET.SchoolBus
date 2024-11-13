using System;
using ET.SchoolBus.Application.Interfaces;
using ET.SchoolBus.Application.Services.Implementaions;
using Microsoft.Extensions.DependencyInjection;

namespace ET.SchoolBus.Application;

public static class ApplicationServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBrandService, BrandService>();
    }
}
