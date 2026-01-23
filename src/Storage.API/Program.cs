using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Storage.API;
using Storage.API.Middleware;
using Storage.BLL.Validators;
using Storage.DAL.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddMapping();
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserRequestValidator>();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddAuthorizationPolicies();
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("WarehouseDb");
builder.Services.AddDbContext<WarehouseContext>(options => options.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();
app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
