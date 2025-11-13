using System.Text;
using System.Text.Json;
using PredictiveMaintenance.Domain.Interfaces;

namespace PredictiveMaintenance.Infrastructure.Services.MLService;

public class MLServiceClient : IMLService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public MLServiceClient(string baseUrl = "http://localhost:8000")
    {
        _baseUrl = baseUrl;
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(baseUrl),
            Timeout = TimeSpan.FromSeconds(30)
        };
    }

    public async Task<PredictionResult> PredictFailureAsync(PredictionRequest request)
    {
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("/api/predict", content);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<PredictionResult>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? throw new Exception("Failed to deserialize prediction result");
    }

    public async Task<AnomalyDetectionResult> DetectAnomalyAsync(AnomalyDetectionRequest request)
    {
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("/api/detect-anomaly", content);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<AnomalyDetectionResult>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? throw new Exception("Failed to deserialize anomaly detection result");
    }
}


