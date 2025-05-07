namespace WebApplication1.Models.DTOs;

public class NewAppointmentDto
{
    public int appointment_Id { get; set; }
    public int patient_id { get; set; }
    public int doctor_id { get; set; }
    public string Type { get; set; }
    public DateTime AppointmentDate { get; set; }
}