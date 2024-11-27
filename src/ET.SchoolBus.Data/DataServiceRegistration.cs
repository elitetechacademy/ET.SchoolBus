using ET.SchoolBus.Data.Context;
using ET.SchoolBus.Data.Repositories.Implementations;
using ET.SchoolBus.Data.Repositories.Interfaces;
using ET.SchoolBus.Data.UnitWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ET.SchoolBus.Data;

public static class DataServiceRegistration
{
    public static void AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SchoolBusContext>(optionsBuilder =>
    optionsBuilder.UseSqlServer(configuration.GetConnectionString("SchoolBusConnection")));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        //Repositories
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IModelRepository, ModelRepository>();
        services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
        services.AddScoped<IProfessionRepository, ProfessionRepository>();
        services.AddScoped<ISchoolRepository, SchoolRepository>();
    }
}
