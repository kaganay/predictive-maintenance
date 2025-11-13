namespace PredictiveMaintenance.Application.DTOs;

public class MaintenancePredictionDto
{
    public int Id { get; set; }
    public int EquipmentId { get; set; }
    public double FailureProbability { get; set; }
    public string PredictionType { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string? RecommendedAction { get; set; }
    public DateTime PredictedDate { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CreatePredictionDto
{
    public int EquipmentId { get; set; }
    public string ModelType { get; set; } = "LSTM";
}
