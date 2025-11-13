using Microsoft.EntityFrameworkCore;
using PredictiveMaintenance.Domain.Entities;
using PredictiveMaintenance.Domain.Interfaces;
using PredictiveMaintenance.Infrastructure.Data;

namespace PredictiveMaintenance.Infrastructure.Repositories;

public class SensorDataRepository : Repository<SensorData>, ISensorDataRepository
{
    public SensorDataRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<SensorData>> GetSensorDataByEquipmentIdAsync(int equipmentId)
    {
        return await _dbSet
            .Where(s => s.EquipmentId == equipmentId)
            .OrderByDescending(s => s.Timestamp)
            .ToListAsync();
    }

    public async Task<IEnumerable<SensorData>> GetSensorDataByDateRangeAsync(int equipmentId, DateTime startDate, DateTime endDate)
    {
        return await _dbSet
            .Where(s => s.EquipmentId == equipmentId && s.Timestamp >= startDate && s.Timestamp <= endDate)
            .OrderBy(s => s.Timestamp)
            .ToListAsync();
    }

    public async Task<IEnumerable<SensorData>> GetAnomaliesAsync(int equipmentId)
    {
        return await _dbSet
            .Where(s => s.EquipmentId == equipmentId && s.IsAnomaly)
            .OrderByDescending(s => s.Timestamp)
            .ToListAsync();
    }

    public async Task<SensorData?> GetLatestSensorDataAsync(int equipmentId)
    {
        return await _dbSet
            .Where(s => s.EquipmentId == equipmentId)
            .OrderByDescending(s => s.Timestamp)
            .FirstOrDefaultAsync();
    }
}

