using PredictiveMaintenance.Domain.Entities;

namespace PredictiveMaintenance.Domain.Interfaces;

public interface IAlertRepository : IRepository<Alert>
{
    Task<IEnumerable<Alert>> GetUnreadAlertsAsync();
    Task<IEnumerable<Alert>> GetAlertsByEquipmentIdAsync(int equipmentId);
    Task<IEnumerable<Alert>> GetAlertsBySeverityAsync(string severity);
    Task MarkAsReadAsync(int alertId);
}

