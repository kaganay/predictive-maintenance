using PredictiveMaintenance.Domain.Entities;

namespace PredictiveMaintenance.Domain.Interfaces;

public interface IMaintenancePredictionRepository : IRepository<MaintenancePrediction>
{
    Task<IEnumerable<MaintenancePrediction>> GetPredictionsByEquipmentIdAsync(int equipmentId);
    Task<MaintenancePrediction?> GetLatestPredictionAsync(int equipmentId);
    Task<IEnumerable<MaintenancePrediction>> GetCriticalPredictionsAsync();
    Task<IEnumerable<MaintenancePrediction>> GetUnprocessedPredictionsAsync();
}

