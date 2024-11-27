using System.Reflection;
using ET.SchoolBus.Application.Interfaces;
using ET.SchoolBus.Application.Services.Implementations;
using ET.SchoolBus.Application.Services.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ET.SchoolBus.Application;

public static class ApplicationServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IModelService, ModelService>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IProfessionService, ProfessionService>();
        services.AddScoped<ISchoolService, SchoolService>();
    }
}
