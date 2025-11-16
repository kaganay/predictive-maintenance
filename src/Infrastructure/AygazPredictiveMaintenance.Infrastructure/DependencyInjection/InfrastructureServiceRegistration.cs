using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PredictiveMaintenance.Domain.Interfaces;
using PredictiveMaintenance.Infrastructure.Data;
using PredictiveMaintenance.Infrastructure.Repositories;
using PredictiveMaintenance.Infrastructure.Services.RabbitMQ;
using PredictiveMaintenance.Infrastructure.Services.Redis;
using PredictiveMaintenance.Infrastructure.Services.MLService;

namespace PredictiveMaintenance.Infrastructure.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Database (with safe fallback)
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=PredictiveMaintenanceDb_Fresh;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True";
        }

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Repositories
        services.AddScoped<IEquipmentRepository, EquipmentRepository>();
        services.AddScoped<ISensorDataRepository, SensorDataRepository>();
        services.AddScoped<IMaintenancePredictionRepository, MaintenancePredictionRepository>();
        services.AddScoped<IAlertRepository, AlertRepository>();
        services.AddScoped<IMaintenanceHistoryRepository, MaintenanceHistoryRepository>();

        // External services
        services.AddSingleton<IMessageQueueService, RabbitMQService>();
        services.AddSingleton<ICacheService, RedisCacheService>();

        // ML Service client registration via factory (uses BaseUrl from config)
        services.AddSingleton<IMLService>(sp =>
        {
            var baseUrl = configuration["MLService:BaseUrl"] ?? "http://localhost:8000";
            return new MLServiceClient(baseUrl);
        });

        return services;
    }
}

