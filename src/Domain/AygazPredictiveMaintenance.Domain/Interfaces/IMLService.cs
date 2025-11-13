namespace PredictiveMaintenance.Domain.Interfaces;

public interface IMLService
{
    Task<PredictionResult> PredictFailureAsync(PredictionRequest request);
    Task<AnomalyDetectionResult> DetectAnomalyAsync(AnomalyDetectionRequest request);
}

public class PredictionRequest
{
    public int EquipmentId { get; set; }
    public List<SensorDataPoint> SensorData { get; set; } = new();
    public string ModelType { get; set; } = "LSTM"; // LSTM, RandomForest, YOLO
}

public class SensorDataPoint
{
    public string SensorType { get; set; } = string.Empty;
    public double Value { get; set; }
    public DateTime Timestamp { get; set; }
}

public class PredictionResult
{
    public int EquipmentId { get; set; }
    public double FailureProbability { get; set; }
    public string Status { get; set; } = "Normal";
    public string? RecommendedAction { get; set; }
    public DateTime PredictedDate { get; set; }
}

public class AnomalyDetectionRequest
{
    public int EquipmentId { get; set; }
    public List<SensorDataPoint> SensorData { get; set; } = new();
}

public class AnomalyDetectionResult
{
    public bool IsAnomaly { get; set; }
    public double AnomalyScore { get; set; }
    public string? Reason { get; set; }
}

