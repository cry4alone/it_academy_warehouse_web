using Microsoft.EntityFrameworkCore;
using Storage.BLL.Services;
using Storage.DAL.Models;
using Storage.DAL.Repositories;

namespace Storage.API;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<MeltService>();
        services.AddScoped<UserService>();
        
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<MeltRepository>();
        services.AddScoped<UserRepository>();
        
        return services;
    }
}