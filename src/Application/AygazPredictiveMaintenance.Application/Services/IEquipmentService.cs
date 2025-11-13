using PredictiveMaintenance.Application.DTOs;

namespace PredictiveMaintenance.Application.Services;

public interface IEquipmentService
{
    Task<IEnumerable<EquipmentDto>> GetAllAsync();
    Task<EquipmentDto?> GetByIdAsync(int id);
    Task<EquipmentDto> CreateAsync(CreateEquipmentDto dto);
    Task UpdateAsync(int id, UpdateEquipmentDto dto);
    Task DeleteAsync(int id);
    Task<IEnumerable<EquipmentDto>> GetByStatusAsync(string status);
}
