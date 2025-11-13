namespace PredictiveMaintenance.Application.DTOs;

public class MaintenanceHistoryDto
{
    public int Id { get; set; }
    public int EquipmentId { get; set; }
    public string EquipmentName { get; set; } = string.Empty;
    public string MaintenanceType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Technician { get; set; } = string.Empty;
    public DateTime MaintenanceDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public double Cost { get; set; }
    public string? Notes { get; set; }
}

public class CreateMaintenanceHistoryDto
{
    public int EquipmentId { get; set; }
    public string MaintenanceType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Technician { get; set; } = string.Empty;
    public DateTime MaintenanceDate { get; set; }
    public double Cost { get; set; }
    public string? Notes { get; set; }
}

