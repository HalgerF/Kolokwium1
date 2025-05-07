namespace WebApplication1.Models.DTOs;

public class AppointmentDto
{
    public int appointment_Id { get; set; }
    public int patient_id { get; set; }
    public int doctor_id { get; set; }
    public string Type { get; set; }
    public DateTime AppointmentDate { get; set; }

}
public class DoctorDto
{
    public int doctor_Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PWZ { get; set; } = string.Empty;
}

public class PatientDto
{
    public int patient_Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
}

public class Appointment_Service
{
    public int appointment_Id { get; set; }
    public int service_id { get; set; }
    public decimal service_fee { get; set; }
}