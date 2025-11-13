namespace PredictiveMaintenance.Application.DTOs;

public class SensorDataDto
{
    public int Id { get; set; }
    public int EquipmentId { get; set; }
    public string SensorType { get; set; } = string.Empty;
    public double Value { get; set; }
    public string Unit { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
    public bool IsAnomaly { get; set; }
}

public class CreateSensorDataDto
{
    public int EquipmentId { get; set; }
    public string SensorType { get; set; } = string.Empty;
    public double Value { get; set; }
    public string Unit { get; set; } = string.Empty;
}
