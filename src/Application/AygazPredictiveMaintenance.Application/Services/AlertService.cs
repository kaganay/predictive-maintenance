using AutoMapper;
using PredictiveMaintenance.Application.DTOs;
using PredictiveMaintenance.Domain.Interfaces;

namespace PredictiveMaintenance.Application.Services;

public class AlertService : IAlertService
{
    private readonly IAlertRepository _repository;
    private readonly IMapper _mapper;

    public AlertService(IAlertRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AlertDto>> GetUnreadAlertsAsync()
    {
        var alerts = await _repository.GetUnreadAlertsAsync();
        return _mapper.Map<IEnumerable<AlertDto>>(alerts);
    }

    public async Task<IEnumerable<AlertDto>> GetByEquipmentIdAsync(int equipmentId)
    {
        var alerts = await _repository.GetAlertsByEquipmentIdAsync(equipmentId);
        return _mapper.Map<IEnumerable<AlertDto>>(alerts);
    }

    public async Task MarkAsReadAsync(int alertId)
    {
        await _repository.MarkAsReadAsync(alertId);
    }
}


