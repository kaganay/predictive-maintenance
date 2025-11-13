using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using PredictiveMaintenance.Domain.Interfaces;

namespace PredictiveMaintenance.Infrastructure.Services;

public class MLServiceClient : IMLService, IDisposable
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public MLServiceClient(IConfiguration configuration, HttpClient httpClient)
    {
        _configuration = configuration;
        _httpClient = httpClient;
        _baseUrl = _configuration["MLService:BaseUrl"] ?? "http://localhost:8000";
        _httpClient.BaseAddress = new Uri(_baseUrl);
        _httpClient.Timeout = TimeSpan.FromSeconds(30);
    }

    public async Task<PredictionResult> PredictFailureAsync(PredictionRequest request)
    {
        try
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/predict", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PredictionResult>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result ?? new PredictionResult
            {
                EquipmentId = request.EquipmentId,
                FailureProbability = 0,
                Status = "Normal",
                PredictedDate = DateTime.UtcNow
            };
        }
        catch (Exception)
        {
            // Fallback to default result if ML service is unavailable
            return new PredictionResult
            {
                EquipmentId = request.EquipmentId,
                FailureProbability = 0,
                Status = "Normal",
                PredictedDate = DateTime.UtcNow
            };
        }
    }

    public async Task<AnomalyDetectionResult> DetectAnomalyAsync(AnomalyDetectionRequest request)
    {
        try
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/detect-anomaly", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<AnomalyDetectionResult>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result ?? new AnomalyDetectionResult
            {
                IsAnomaly = false,
                AnomalyScore = 0
            };
        }
        catch (Exception)
        {
            // Fallback to default result if ML service is unavailable
            return new AnomalyDetectionResult
            {
                IsAnomaly = false,
                AnomalyScore = 0
            };
        }
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }
}

