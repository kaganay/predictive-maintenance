using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using PredictiveMaintenance.Application.Mappings;
using PredictiveMaintenance.Application.Services;

namespace PredictiveMaintenance.Application.DependencyInjection;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // AutoMapper
        services.AddAutoMapper(typeof(MappingProfile));

        // Services
        services.AddScoped<IEquipmentService, EquipmentService>();
        services.AddScoped<ISensorDataService, SensorDataService>();
        services.AddScoped<IPredictionService, PredictionService>();
        services.AddScoped<IAlertService, AlertService>();

        return services;
    }
}

