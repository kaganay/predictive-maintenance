using PredictiveMaintenance.Application.DTOs;

namespace PredictiveMaintenance.Application.Services;

public interface IPredictionService
{
    Task<MaintenancePredictionDto> CreatePredictionAsync(CreatePredictionDto dto);
    Task<IEnumerable<MaintenancePredictionDto>> GetByEquipmentIdAsync(int equipmentId);
    Task<MaintenancePredictionDto?> GetLatestAsync(int equipmentId);
    Task<IEnumerable<MaintenancePredictionDto>> GetCriticalPredictionsAsync();
}
