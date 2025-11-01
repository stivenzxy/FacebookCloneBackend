using FacebookClone.Data;
using FacebookClone.Data.Repositories;
using FacebookClone.Interfaces;
using FacebookClone.Services;
using Microsoft.EntityFrameworkCore;

namespace FacebookClone.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlDatabase");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("La cadena de conexión 'SqlDatabase' no se encontró.");
        }
        
        services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(connectionString));
        
        services.AddScoped<ILoginRepository, LoginRepository>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return services;
    }
}