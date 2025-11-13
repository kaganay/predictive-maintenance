using AutoMapper;
using PredictiveMaintenance.Application.DTOs;
using PredictiveMaintenance.Domain.Entities;
using PredictiveMaintenance.Domain.Interfaces;

namespace PredictiveMaintenance.Application.Services;

public class PredictionService : IPredictionService
{
    private readonly IMaintenancePredictionRepository _predictionRepository;
    private readonly ISensorDataRepository _sensorDataRepository;
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IMLService _mlService;
    private readonly IMapper _mapper;

    public PredictionService(
        IMaintenancePredictionRepository predictionRepository,
        ISensorDataRepository sensorDataRepository,
        IEquipmentRepository equipmentRepository,
        IMLService mlService,
        IMapper mapper)
    {
        _predictionRepository = predictionRepository;
        _sensorDataRepository = sensorDataRepository;
        _equipmentRepository = equipmentRepository;
        _mlService = mlService;
        _mapper = mapper;
    }

    public async Task<MaintenancePredictionDto> CreatePredictionAsync(CreatePredictionDto dto)
    {
        // Get recent sensor data
        var recentData = await _sensorDataRepository.GetSensorDataByEquipmentIdAsync(dto.EquipmentId);
        var sensorDataPoints = recentData
            .Take(100)
            .Select(s => new Domain.Interfaces.SensorDataPoint
            {
                SensorType = s.SensorType,
                Value = s.Value,
                Timestamp = s.Timestamp
            })
            .ToList();

        // Call ML Service
        var predictionRequest = new Domain.Interfaces.PredictionRequest
        {
            EquipmentId = dto.EquipmentId,
            SensorData = sensorDataPoints,
            ModelType = dto.ModelType
        };

        var predictionResult = await _mlService.PredictFailureAsync(predictionRequest);

        // Save prediction
        var prediction = new MaintenancePrediction
        {
            EquipmentId = dto.EquipmentId,
            FailureProbability = predictionResult.FailureProbability,
            PredictionType = dto.ModelType,
            Status = predictionResult.Status,
            RecommendedAction = predictionResult.RecommendedAction,
            PredictedDate = predictionResult.PredictedDate
        };

        var created = await _predictionRepository.AddAsync(prediction);
        return _mapper.Map<MaintenancePredictionDto>(created);
    }

    public async Task<IEnumerable<MaintenancePredictionDto>> GetByEquipmentIdAsync(int equipmentId)
    {
        var predictions = await _predictionRepository.GetPredictionsByEquipmentIdAsync(equipmentId);
        return _mapper.Map<IEnumerable<MaintenancePredictionDto>>(predictions);
    }

    public async Task<MaintenancePredictionDto?> GetLatestAsync(int equipmentId)
    {
        var prediction = await _predictionRepository.GetLatestPredictionAsync(equipmentId);
        return prediction == null ? null : _mapper.Map<MaintenancePredictionDto>(prediction);
    }

    public async Task<IEnumerable<MaintenancePredictionDto>> GetCriticalPredictionsAsync()
    {
        var predictions = await _predictionRepository.GetCriticalPredictionsAsync();
        return _mapper.Map<IEnumerable<MaintenancePredictionDto>>(predictions);
    }
}
