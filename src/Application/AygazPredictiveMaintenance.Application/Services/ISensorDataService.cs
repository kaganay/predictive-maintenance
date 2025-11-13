using PredictiveMaintenance.Application.DTOs;

namespace PredictiveMaintenance.Application.Services;

public interface ISensorDataService
{
    Task<IEnumerable<SensorDataDto>> GetByEquipmentIdAsync(int equipmentId);
    Task<IEnumerable<SensorDataDto>> GetByDateRangeAsync(int equipmentId, DateTime startDate, DateTime endDate);
    Task<SensorDataDto> CreateAsync(CreateSensorDataDto dto);
    Task<IEnumerable<SensorDataDto>> GetAnomaliesAsync(int equipmentId);
}
