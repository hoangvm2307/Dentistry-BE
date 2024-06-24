using DentistryServices;
using DTOs.AppointmentDtos;
using Microsoft.AspNetCore.Mvc;


namespace prn_dentistry.API.Controllers
{
  public class AppointmentsController : BaseApiController
  {
    private readonly IAppointmentService _appointmentService;

    public AppointmentsController(IAppointmentService appointmentService)
    {
      _appointmentService = appointmentService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAllAppointments()
    {
      var appointments = await _appointmentService.GetAllAppointmentsAsync();

      return Ok(appointments);

      // return Ok("Helloworld");
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppointmentDto>> GetAppointment(int id)
    {
      var appointment = await _appointmentService.GetAppointmentByIdAsync(id);

      if (appointment == null) return NotFound();

      return Ok(appointment);
    }

    [HttpPost]
    public async Task<ActionResult<AppointmentDto>> CreateAppointment(AppointmentCreateDto appointmentCreateDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var appointment = await _appointmentService.CreateAppointmentAsync(appointmentCreateDto);

      return CreatedAtAction(nameof(GetAppointment), new { id = appointment.AppointmentID }, appointment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAppointment(int id, AppointmentUpdateDto appointmentUpdateDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var appointment = await _appointmentService.UpdateAppointmentAsync(id, appointmentUpdateDto);

      if (appointment == null) return NotFound();

      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppointment(int id)
    {
      var success = await _appointmentService.DeleteAppointmentAsync(id);

      if (!success) return NotFound();

      return NoContent();
    }
  }
}