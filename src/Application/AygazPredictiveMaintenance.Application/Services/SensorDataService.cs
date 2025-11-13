using AutoMapper;
using PredictiveMaintenance.Application.DTOs;
using PredictiveMaintenance.Domain.Interfaces;

namespace PredictiveMaintenance.Application.Services;

public class SensorDataService : ISensorDataService
{
    private readonly ISensorDataRepository _repository;
    private readonly IMapper _mapper;

    public SensorDataService(ISensorDataRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SensorDataDto>> GetByEquipmentIdAsync(int equipmentId)
    {
        var sensorData = await _repository.GetSensorDataByEquipmentIdAsync(equipmentId);
        return _mapper.Map<IEnumerable<SensorDataDto>>(sensorData);
    }

    public async Task<IEnumerable<SensorDataDto>> GetByDateRangeAsync(int equipmentId, DateTime startDate, DateTime endDate)
    {
        var sensorData = await _repository.GetSensorDataByDateRangeAsync(equipmentId, startDate, endDate);
        return _mapper.Map<IEnumerable<SensorDataDto>>(sensorData);
    }

    public async Task<SensorDataDto> CreateAsync(CreateSensorDataDto dto)
    {
        var sensorData = _mapper.Map<Domain.Entities.SensorData>(dto);
        var created = await _repository.AddAsync(sensorData);
        return _mapper.Map<SensorDataDto>(created);
    }

    public async Task<IEnumerable<SensorDataDto>> GetAnomaliesAsync(int equipmentId)
    {
        var anomalies = await _repository.GetAnomaliesAsync(equipmentId);
        return _mapper.Map<IEnumerable<SensorDataDto>>(anomalies);
    }
}
