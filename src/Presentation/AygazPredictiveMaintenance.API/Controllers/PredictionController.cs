using Microsoft.AspNetCore.Mvc;
using PredictiveMaintenance.Application.DTOs;
using PredictiveMaintenance.Application.Services;

namespace PredictiveMaintenance.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PredictionController : ControllerBase
{
    private readonly IPredictionService _service;

    public PredictionController(IPredictionService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<MaintenancePredictionDto>> CreatePrediction([FromBody] CreatePredictionDto dto)
    {
        var prediction = await _service.CreatePredictionAsync(dto);
        return Ok(prediction);
    }

    [HttpGet("equipment/{equipmentId}")]
    public async Task<ActionResult<IEnumerable<MaintenancePredictionDto>>> GetByEquipmentId(int equipmentId)
    {
        var predictions = await _service.GetByEquipmentIdAsync(equipmentId);
        return Ok(predictions);
    }

    [HttpGet("equipment/{equipmentId}/latest")]
    public async Task<ActionResult<MaintenancePredictionDto>> GetLatest(int equipmentId)
    {
        var prediction = await _service.GetLatestAsync(equipmentId);
        if (prediction == null)
            return NotFound();
        return Ok(prediction);
    }

    [HttpGet("critical")]
    public async Task<ActionResult<IEnumerable<MaintenancePredictionDto>>> GetCritical()
    {
        var predictions = await _service.GetCriticalPredictionsAsync();
        return Ok(predictions);
    }
}
