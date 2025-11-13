namespace PredictiveMaintenance.Domain.Entities;

public class MaintenanceHistory
{
    public int Id { get; set; }
    public int EquipmentId { get; set; }
    public string MaintenanceType { get; set; } = string.Empty; // Preventive, Corrective, Predictive
    public string Description { get; set; } = string.Empty;
    public string Technician { get; set; } = string.Empty;
    public DateTime MaintenanceDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public double Cost { get; set; }
    public string? Notes { get; set; }
    
    // Navigation property
    public virtual Equipment Equipment { get; set; } = null!;
}

