using AutoMapper;
using PredictiveMaintenance.Application.DTOs;
using PredictiveMaintenance.Domain.Interfaces;

namespace PredictiveMaintenance.Application.Services;

public class EquipmentService : IEquipmentService
{
    private readonly IEquipmentRepository _repository;
    private readonly IMapper _mapper;

    public EquipmentService(IEquipmentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EquipmentDto>> GetAllAsync()
    {
        var equipments = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<EquipmentDto>>(equipments);
    }

    public async Task<EquipmentDto?> GetByIdAsync(int id)
    {
        var equipment = await _repository.GetByIdAsync(id);
        return equipment == null ? null : _mapper.Map<EquipmentDto>(equipment);
    }

    public async Task<EquipmentDto> CreateAsync(CreateEquipmentDto dto)
    {
        var equipment = _mapper.Map<Domain.Entities.Equipment>(dto);
        var created = await _repository.AddAsync(equipment);
        return _mapper.Map<EquipmentDto>(created);
    }

    public async Task UpdateAsync(int id, UpdateEquipmentDto dto)
    {
        var equipment = await _repository.GetByIdAsync(id);
        if (equipment == null)
            throw new KeyNotFoundException($"Equipment with id {id} not found");

        _mapper.Map(dto, equipment);
        await _repository.UpdateAsync(equipment);
    }

    public async Task DeleteAsync(int id)
    {
        var equipment = await _repository.GetByIdAsync(id);
        if (equipment == null)
            throw new KeyNotFoundException($"Equipment with id {id} not found");

        await _repository.DeleteAsync(equipment);
    }

    public async Task<IEnumerable<EquipmentDto>> GetByStatusAsync(string status)
    {
        var equipments = await _repository.GetEquipmentsByStatusAsync(status);
        return _mapper.Map<IEnumerable<EquipmentDto>>(equipments);
    }
}
