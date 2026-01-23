using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Storage.API.Authorization;
using Storage.BLL.Common.Services;
using Storage.BLL.Common.Services.Interfaces;
using Storage.BLL.Mappings;
using Storage.BLL.Services;
using Storage.BLL.Services.Interfaces;
using Storage.DAL.Repositories;
using Storage.DAL.Repositories.Interfaces;

namespace Storage.API;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthorizationHandler, PermissionHandler>();
        
        services.AddScoped<IMeltService, MeltService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<ICertificateService, CertificateService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IAcceptanceInvoiceService, AcceptanceInvoiceService>();
        
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
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        
        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Введите 'Bearer' [пробел] и ваш JWT-токен.\n\nПример: \"Bearer eyJhbGciOi...\""
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    []
                }
            });
        });
        
        return services;
    }

    public static IServiceCollection AddMapping(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => { },
            typeof(UserProfile),
            typeof(MeltProfile),
            typeof(CertificateProfile),
            typeof(RoleProfile));
        
        return services;
    }

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"] ?? string.Empty))
                };
            });
        
        return services;
    }

    public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
    {
        services.AddAuthorizationBuilder()  
            .AddPolicy("Melt.View", policy => policy.Requirements.Add(new PermissionRequirement("Melt.View")))
            .AddPolicy("Melt.Delete", policy => policy.Requirements.Add(new PermissionRequirement("Melt.Delete")))
            .AddPolicy("User.Create", policy => policy.Requirements.Add(new PermissionRequirement("User.Create")))
            .AddPolicy("User.View", policy => policy.Requirements.Add(new PermissionRequirement("User.View")))
            .AddPolicy("Certificate.View", policy => policy.Requirements.Add(new PermissionRequirement("Certificate.View")))
            .AddPolicy("Certificate.Create", policy => policy.Requirements.Add(new PermissionRequirement("Certificate.Create")))
            .AddPolicy("Certificate.Sign", policy => policy.Requirements.Add(new PermissionRequirement("Certificate.Sign")));
        
        return services;
    }
    
}