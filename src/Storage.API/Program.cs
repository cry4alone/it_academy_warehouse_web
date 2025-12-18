using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Storage.API;
using Storage.API.Authorization;
using Storage.BLL.Mappings;
using Storage.DAL.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
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

builder.Services.AddAutoMapper(cfg => { },
    typeof(UserProfile),
    typeof(MeltProfile),
    typeof(CertificateProfile));

builder.Services.AddHttpContextAccessor();

var connectionString = builder.Configuration.GetConnectionString("WarehouseDb");
builder.Services.AddDbContext<WarehouseContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"] ?? string.Empty))
        };
    });

builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Melt.View", policy => policy.Requirements.Add(new PermissionRequirement("Melt.View")));
    options.AddPolicy("User.Create", policy => policy.Requirements.Add(new PermissionRequirement("User.Create")));
    options.AddPolicy("User.View", policy => policy.Requirements.Add(new PermissionRequirement("User.View")));
    options.AddPolicy("Certificate.View", policy => policy.Requirements.Add(new PermissionRequirement("Certificate.View")));
    options.AddPolicy("Certificate.Create", policy => policy.Requirements.Add(new PermissionRequirement("Certificate.Create")));
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
