using Microsoft.AspNetCore.Mvc;
using PredictiveMaintenance.Application.DTOs;
using PredictiveMaintenance.Application.Services;

namespace PredictiveMaintenance.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquipmentController : ControllerBase
{
    private readonly IEquipmentService _service;

    public EquipmentController(IEquipmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EquipmentDto>>> GetAll()
    {
        var equipments = await _service.GetAllAsync();
        return Ok(equipments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EquipmentDto>> GetById(int id)
    {
        var equipment = await _service.GetByIdAsync(id);
        if (equipment == null)
            return NotFound();
        return Ok(equipment);
    }

    [HttpPost]
    public async Task<ActionResult<EquipmentDto>> Create([FromBody] CreateEquipmentDto dto)
    {
        var equipment = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = equipment.Id }, equipment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateEquipmentDto dto)
    {
        try
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("status/{status}")]
    public async Task<ActionResult<IEnumerable<EquipmentDto>>> GetByStatus(string status)
    {
        var equipments = await _service.GetByStatusAsync(status);
        return Ok(equipments);
    }
}
