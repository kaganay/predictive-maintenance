using PredictiveMaintenance.Domain.Entities;

namespace PredictiveMaintenance.Domain.Interfaces;

public interface IEquipmentRepository : IRepository<Equipment>
{
    Task<Equipment?> GetEquipmentWithSensorDataAsync(int id);
    Task<IEnumerable<Equipment>> GetEquipmentsByStatusAsync(string status);
    Task<IEnumerable<Equipment>> GetEquipmentsNeedingMaintenanceAsync();
}

