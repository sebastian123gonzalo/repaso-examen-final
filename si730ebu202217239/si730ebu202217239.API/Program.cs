using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using si730ebu202217239.inventory.Application.Internal.CommandServices;
using si730ebu202217239.inventory.Application.Internal.QueryServices;
using si730ebu202217239.inventory.Domain.Repositories;
using si730ebu202217239.inventory.Domain.Services;
using si730ebu202217239.inventory.Infrastructure.Persistence.EFC.Repositories;
using si730ebu202217239.inventory.Interfaces.ACL;
using si730ebu202217239.inventory.Interfaces.ACL.Services;
using si730ebu202217239.maintenance.Application.Internal.CommandServices;
using si730ebu202217239.maintenance.Application.Internal.OutboundServices.ACL;
using si730ebu202217239.maintenance.Application.Internal.OutboundServices.ACL.Services;
using si730ebu202217239.maintenance.Application.Internal.QueryServices;
using si730ebu202217239.maintenance.Domain.Services;
using si730ebu202217239.maintenance.Infrastructure.Persistence.EFC.Repositories;
using si730ebu202217239.Shared.Domain.Repositories;
using si730ebu202217239.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu202217239.Shared.Infrastructure.Persistence.EFC.Repositories;
using si730ebu202217239.Shared.Interfaces.ASP.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if(connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// OpenApi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "REPASO PARCIAL APPS WEB",
                Version = "v1",
                Description = "Platform API",
                TermsOfService = new Uri("https://example.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "API EXAMPLE Platform",
                    Email = "contact@example.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});
 

// Configure Dependency Injection

//Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Inventory Bounded Context Injection Configuration
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductQueryService, ProductQueryService>();
builder.Services.AddScoped<IProductCommandService, ProductCommandService>();
builder.Services.AddScoped<IProductsContextFacade, ProductsContextFacade>();

//Maintenance Bounded Context Injection Configuration
builder.Services.AddScoped<IMaintenanceActivityRepository, MaintenanceActivityRepository>();
builder.Services.AddScoped<IMaintenanceActivityQueryService, MaintenanceActivityQueryService>();
builder.Services.AddScoped<IMaintenanceActivityCommandService, MaintenanceActivityCommandService>();
builder.Services.AddScoped<IExternalProductService, ExternalProductService>();
/*
 * 
 * BOUNDED CONTEXTS INJECTION CONFIGURATION
 * 
*/

var app = builder.Build();

//Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

