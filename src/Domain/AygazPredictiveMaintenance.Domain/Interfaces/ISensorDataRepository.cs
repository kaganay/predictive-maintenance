using PredictiveMaintenance.Domain.Entities;

namespace PredictiveMaintenance.Domain.Interfaces;

public interface ISensorDataRepository : IRepository<SensorData>
{
    Task<IEnumerable<SensorData>> GetSensorDataByEquipmentIdAsync(int equipmentId);
    Task<IEnumerable<SensorData>> GetSensorDataByDateRangeAsync(int equipmentId, DateTime startDate, DateTime endDate);
    Task<IEnumerable<SensorData>> GetAnomaliesAsync(int equipmentId);
    Task<SensorData?> GetLatestSensorDataAsync(int equipmentId);
}

