using Microsoft.EntityFrameworkCore;
using PredictiveMaintenance.Domain.Entities;
using PredictiveMaintenance.Domain.Interfaces;
using PredictiveMaintenance.Infrastructure.Data;

namespace PredictiveMaintenance.Infrastructure.Repositories;

public class MaintenanceHistoryRepository : Repository<MaintenanceHistory>, IMaintenanceHistoryRepository
{
    public MaintenanceHistoryRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<MaintenanceHistory>> GetHistoryByEquipmentIdAsync(int equipmentId)
    {
        return await _dbSet
            .Where(h => h.EquipmentId == equipmentId)
            .OrderByDescending(h => h.MaintenanceDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<MaintenanceHistory>> GetHistoryByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _dbSet
            .Where(h => h.MaintenanceDate >= startDate && h.MaintenanceDate <= endDate)
            .OrderByDescending(h => h.MaintenanceDate)
            .ToListAsync();
    }
}
