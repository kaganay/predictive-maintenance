using PredictiveMaintenance.Application.DTOs;

namespace PredictiveMaintenance.Application.Services;

public interface IAlertService
{
    Task<IEnumerable<AlertDto>> GetUnreadAlertsAsync();
    Task<IEnumerable<AlertDto>> GetByEquipmentIdAsync(int equipmentId);
    Task MarkAsReadAsync(int alertId);
}


