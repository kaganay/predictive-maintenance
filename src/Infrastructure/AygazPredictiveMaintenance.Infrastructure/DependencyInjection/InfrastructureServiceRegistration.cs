using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PredictiveMaintenance.Domain.Interfaces;
using PredictiveMaintenance.Infrastructure.Data;
using PredictiveMaintenance.Infrastructure.Repositories;
using PredictiveMaintenance.Infrastructure.Services;

namespace PredictiveMaintenance.Infrastructure.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Database
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Repositories
        services.AddScoped<IEquipmentRepository, EquipmentRepository>();
        services.AddScoped<ISensorDataRepository, SensorDataRepository>();
        services.AddScoped<IMaintenancePredictionRepository, MaintenancePredictionRepository>();
        services.AddScoped<IAlertRepository, AlertRepository>();
        services.AddScoped<IMaintenanceHistoryRepository, MaintenanceHistoryRepository>();

        // Services
        services.AddSingleton<IMessageQueueService, RabbitMQService>();
        services.AddSingleton<ICacheService, RedisCacheService>();
        services.AddHttpClient<IMLService, MLServiceClient>();
        services.AddScoped<IMLService, MLServiceClient>();

        return services;
    }
}

