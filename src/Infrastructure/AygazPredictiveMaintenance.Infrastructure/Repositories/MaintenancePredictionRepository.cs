using Microsoft.EntityFrameworkCore;
using PredictiveMaintenance.Domain.Entities;
using PredictiveMaintenance.Domain.Interfaces;
using PredictiveMaintenance.Infrastructure.Data;

namespace PredictiveMaintenance.Infrastructure.Repositories;

public class MaintenancePredictionRepository : Repository<MaintenancePrediction>, IMaintenancePredictionRepository
{
    public MaintenancePredictionRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<MaintenancePrediction>> GetPredictionsByEquipmentIdAsync(int equipmentId)
    {
        return await _dbSet
            .Where(p => p.EquipmentId == equipmentId)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
    }

    public async Task<MaintenancePrediction?> GetLatestPredictionAsync(int equipmentId)
    {
        return await _dbSet
            .Where(p => p.EquipmentId == equipmentId)
            .OrderByDescending(p => p.CreatedAt)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<MaintenancePrediction>> GetCriticalPredictionsAsync()
    {
        return await _dbSet
            .Where(p => p.Status == "Critical" || p.FailureProbability >= 80)
            .OrderByDescending(p => p.FailureProbability)
            .ToListAsync();
    }

    public async Task<IEnumerable<MaintenancePrediction>> GetUnprocessedPredictionsAsync()
    {
        return await _dbSet
            .Where(p => !p.IsProcessed)
            .OrderBy(p => p.CreatedAt)
            .ToListAsync();
    }
}
