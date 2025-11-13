using AutoMapper;
using PredictiveMaintenance.Application.DTOs;
using PredictiveMaintenance.Domain.Entities;

namespace PredictiveMaintenance.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Equipment Mappings
        CreateMap<Equipment, EquipmentDto>().ReverseMap();
        CreateMap<CreateEquipmentDto, Equipment>();
        CreateMap<UpdateEquipmentDto, Equipment>();

        // SensorData Mappings
        CreateMap<SensorData, SensorDataDto>().ReverseMap();
        CreateMap<CreateSensorDataDto, SensorData>();

        // MaintenancePrediction Mappings
        CreateMap<MaintenancePrediction, MaintenancePredictionDto>().ReverseMap();

        // Alert Mappings
        CreateMap<Alert, AlertDto>()
            .ForMember(dest => dest.EquipmentName, opt => opt.MapFrom(src => src.Equipment.Name));
    }
}
