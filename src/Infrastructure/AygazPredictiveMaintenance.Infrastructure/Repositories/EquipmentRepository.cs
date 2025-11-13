using Microsoft.EntityFrameworkCore;
using PredictiveMaintenance.Domain.Entities;
using PredictiveMaintenance.Domain.Interfaces;
using PredictiveMaintenance.Infrastructure.Data;

namespace PredictiveMaintenance.Infrastructure.Repositories;

public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
{
    public EquipmentRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Equipment?> GetEquipmentWithSensorDataAsync(int id)
    {
        return await _dbSet
            .Include(e => e.SensorData.OrderByDescending(s => s.Timestamp).Take(100))
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<Equipment>> GetEquipmentsByStatusAsync(string status)
    {
        return await _dbSet
            .Where(e => e.Status == status)
            .ToListAsync();
    }

    public async Task<IEnumerable<Equipment>> GetEquipmentsNeedingMaintenanceAsync()
    {
        var now = DateTime.UtcNow;
        return await _dbSet
            .Where(e => e.NextMaintenanceDate.HasValue && e.NextMaintenanceDate <= now)
            .ToListAsync();
    }
}
