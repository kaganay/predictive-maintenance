namespace PredictiveMaintenance.Domain.Entities;

public class SensorData
{
    public int Id { get; set; }
    public int EquipmentId { get; set; }
    public string SensorType { get; set; } = string.Empty; // Pressure, Temperature, Vibration, Current
    public double Value { get; set; }
    public string Unit { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public bool IsAnomaly { get; set; } = false;
    
    // Navigation property
    public virtual Equipment Equipment { get; set; } = null!;
}

