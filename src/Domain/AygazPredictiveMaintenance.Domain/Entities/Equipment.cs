namespace PredictiveMaintenance.Domain.Entities;

public class Equipment
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // Pump, Valve, Motor, PressureSensor
    public string Location { get; set; } = string.Empty;
    public string Status { get; set; } = "Normal"; // Normal, Warning, Critical
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastMaintenanceDate { get; set; }
    public DateTime? NextMaintenanceDate { get; set; }
    
    // Navigation properties
    public virtual ICollection<SensorData> SensorData { get; set; } = new List<SensorData>();
    public virtual ICollection<MaintenancePrediction> MaintenancePredictions { get; set; } = new List<MaintenancePrediction>();
    public virtual ICollection<MaintenanceHistory> MaintenanceHistories { get; set; } = new List<MaintenanceHistory>();
    public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();
}

