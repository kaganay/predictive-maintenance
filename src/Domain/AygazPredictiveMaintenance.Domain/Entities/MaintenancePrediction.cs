namespace PredictiveMaintenance.Domain.Entities;

public class MaintenancePrediction
{
    public int Id { get; set; }
    public int EquipmentId { get; set; }
    public double FailureProbability { get; set; } // 0-100
    public string PredictionType { get; set; } = string.Empty; // LSTM, RandomForest, YOLO
    public string Status { get; set; } = "Normal"; // Normal, Warning, Critical
    public string? RecommendedAction { get; set; }
    public DateTime PredictedDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsProcessed { get; set; } = false;
    
    // Navigation property
    public virtual Equipment Equipment { get; set; } = null!;
}

