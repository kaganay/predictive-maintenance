using Microsoft.AspNetCore.Mvc;
using PredictiveMaintenance.Application.DTOs;
using PredictiveMaintenance.Application.Services;

namespace PredictiveMaintenance.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlertController : ControllerBase
{
    private readonly IAlertService _service;

    public AlertController(IAlertService service)
    {
        _service = service;
    }

    [HttpGet("unread")]
    public async Task<ActionResult<IEnumerable<AlertDto>>> GetUnread()
    {
        var alerts = await _service.GetUnreadAlertsAsync();
        return Ok(alerts);
    }

    [HttpGet("equipment/{equipmentId}")]
    public async Task<ActionResult<IEnumerable<AlertDto>>> GetByEquipmentId(int equipmentId)
    {
        var alerts = await _service.GetByEquipmentIdAsync(equipmentId);
        return Ok(alerts);
    }

    [HttpPut("{id}/read")]
    public async Task<IActionResult> MarkAsRead(int id)
    {
        await _service.MarkAsReadAsync(id);
        return NoContent();
    }
}


