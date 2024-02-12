using DriverManagementSystem.Domain.Primitives;
using DriverManagementSystem.Domain.Repositories;
using DriverManagementSystem.Infrastructure.DataAccess;
using DriverManagementSystem.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DriverManagementSystem.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ApplicationDbContext>();

        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
        services.AddScoped<IDriverRepository, DriverRepository>();

        services.AddSingleton<DriverQueries>();

    }
}

