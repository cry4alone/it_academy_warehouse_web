using Microsoft.AspNetCore.Authorization;
using Storage.API.Authorization;
using Storage.BLL.Common;
using Storage.BLL.Common.Services;
using Storage.BLL.Common.Services.Interfaces;
using Storage.BLL.Services;
using Storage.BLL.Services.Interfaces;
using Storage.DAL.Repositories;
using Storage.DAL.Repositories.Interfaces;

namespace Storage.API;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthorizationHandler, PermissionHandler>();
        
        services.AddScoped<IMeltService, MeltService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<ICertificateService, CertificateService>();
        
        services.AddSingleton<IPasswordHashingService, PasswordHashingService>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IMeltRepository, MeltRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICertificatesRepository, CertificateRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        
        return services;
    }
    
}