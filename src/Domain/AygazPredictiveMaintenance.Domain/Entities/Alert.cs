namespace PredictiveMaintenance.Domain.Entities;

public class Alert
{
    public int Id { get; set; }
    public int EquipmentId { get; set; }
    public string AlertType { get; set; } = string.Empty; // Maintenance, Critical, Warning
    public string Message { get; set; } = string.Empty;
    public string Severity { get; set; } = "Info"; // Info, Warning, Critical
    public bool IsRead { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ResolvedAt { get; set; }
    
    // Navigation property
    public virtual Equipment Equipment { get; set; } = null!;
}

