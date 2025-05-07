using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase {
    private readonly IAppointmentService _appointmentService;
    private readonly string _connectionString;

    public AppointmentsController(IConfiguration configuration)
    {
        _connectionString =
            configuration.GetConnectionString(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=APBD;Integrated Security=True;");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAppointment(int id) {
        var result = await _appointmentService.GetAppointmentByIdAsync(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddAppointment([FromBody] NewAppointmentDto dto) {
        var result = await _appointmentService.AddAppointmentAsync(dto);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        return CreatedAtAction(nameof(GetAppointment), new { id = result.AppointmentId }, null);
    }
}