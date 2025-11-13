using PredictiveMaintenance.Domain.Entities;

namespace PredictiveMaintenance.Domain.Interfaces;

public interface IMaintenanceHistoryRepository : IRepository<MaintenanceHistory>
{
    Task<IEnumerable<MaintenanceHistory>> GetHistoryByEquipmentIdAsync(int equipmentId);
    Task<IEnumerable<MaintenanceHistory>> GetHistoryByDateRangeAsync(DateTime startDate, DateTime endDate);
}

