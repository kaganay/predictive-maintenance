using Microsoft.EntityFrameworkCore;
using PredictiveMaintenance.Domain.Entities;
using PredictiveMaintenance.Domain.Interfaces;
using PredictiveMaintenance.Infrastructure.Data;

namespace PredictiveMaintenance.Infrastructure.Repositories;

public class AlertRepository : Repository<Alert>, IAlertRepository
{
    public AlertRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Alert>> GetUnreadAlertsAsync()
    {
        return await _dbSet
            .Where(a => !a.IsRead)
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Alert>> GetAlertsByEquipmentIdAsync(int equipmentId)
    {
        return await _dbSet
            .Where(a => a.EquipmentId == equipmentId)
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Alert>> GetAlertsBySeverityAsync(string severity)
    {
        return await _dbSet
            .Where(a => a.Severity == severity)
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();
    }

    public async Task MarkAsReadAsync(int alertId)
    {
        var alert = await _dbSet.FindAsync(alertId);
        if (alert != null)
        {
            alert.IsRead = true;
            await _context.SaveChangesAsync();
        }
    }
}
