using WebApplication1.Models.DTOs;

namespace WebApplication1.Services;

public interface IAppointmentService {
    Task<AppointmentDto?> GetAppointmentByIdAsync(int id);
    Task<(bool IsSuccess, string Message, int AppointmentId)> AddAppointmentAsync(NewAppointmentDto dto);
}