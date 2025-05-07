using Microsoft.AspNetCore.Mvc;
using WebApplication1.Exceptions;
using WebApplication1.Models.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _AppointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
             _AppointmentService=appointmentService;
        }

        [HttpGet("{id}/rentals")]
        public async Task<IActionResult> GetApointments(int id)
        {
            try
            {
                var res = await _AppointmentService.GetAppointmentByIdAsync(id);
                return Ok(res);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost("{id}/rentals")]
        public async Task<IActionResult> AddNewRental(int id, NewAppointmentDto newAppointmentDto)
        {
            try
            {
                await _AppointmentService.AddAppointmentAsync(newAppointmentDto);
            }
            catch (ConflictException e)
            {
                return Conflict(e.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            
            return CreatedAtAction(nameof(GetApointments), new { id });
        }    
    }
}