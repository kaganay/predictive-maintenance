using Microsoft.AspNetCore.Mvc;
using PredictiveMaintenance.Application.DTOs;
using PredictiveMaintenance.Application.Services;

namespace PredictiveMaintenance.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SensorDataController : ControllerBase
{
    private readonly ISensorDataService _service;

    public SensorDataController(ISensorDataService service)
    {
        _service = service;
    }

    [HttpGet("equipment/{equipmentId}")]
    public async Task<ActionResult<IEnumerable<SensorDataDto>>> GetByEquipmentId(int equipmentId)
    {
        var sensorData = await _service.GetByEquipmentIdAsync(equipmentId);
        return Ok(sensorData);
    }

    [HttpGet("equipment/{equipmentId}/range")]
    public async Task<ActionResult<IEnumerable<SensorDataDto>>> GetByDateRange(
        int equipmentId,
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate)
    {
        var sensorData = await _service.GetByDateRangeAsync(equipmentId, startDate, endDate);
        return Ok(sensorData);
    }

    [HttpPost]
    public async Task<ActionResult<SensorDataDto>> Create([FromBody] CreateSensorDataDto dto)
    {
        var sensorData = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetByEquipmentId), new { equipmentId = sensorData.EquipmentId }, sensorData);
    }

    [HttpGet("equipment/{equipmentId}/anomalies")]
    public async Task<ActionResult<IEnumerable<SensorDataDto>>> GetAnomalies(int equipmentId)
    {
        var anomalies = await _service.GetAnomaliesAsync(equipmentId);
        return Ok(anomalies);
    }
}
