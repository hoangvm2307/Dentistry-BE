using System.Text.Json;
using DentistryRepositories.Extensions;
using DentistryServices;
using DTOs.AppointmentDtos;
using Microsoft.AspNetCore.Authorization;
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

    /// <summary>
    /// Get all appointments
    /// Role: Customer, Dentist, ClinicOwner
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /Appointments
    ///     PARAMS:
    ///         ClinicID: 1 (filter by clinic id)
    ///         DentistID: 1 (filter by dentist id)
    ///         CustomerID: 1 (filter by customer id)
    ///         OrderBy: dateAsc/_(dateDesc)/
    ///         Status: fulfilled/pending
    /// </remarks>
    [HttpGet]
    [Authorize(Roles = "Customer,Dentist,ClinicOwner")]
    public async Task<ActionResult<PagedList<AppointmentDto>>> GetAllAppointments([FromQuery] AppointmentQueryParams queryParams)
    {
      var appointments = await _appointmentService.GetAllAppointmentsAsync(queryParams);
      Response.Headers.Add("Pagination", JsonSerializer.Serialize(appointments.MetaData));
      return Ok(appointments);
    }

    /// <summary>
    /// Get an appointment by id
    /// Role: Customer, Dentist, ClinicOwner
    /// </summary>
    [HttpGet("{id}")]
    [Authorize(Roles = "Customer,Dentist,ClinicOwner")]
    public async Task<ActionResult<AppointmentDto>> GetAppointment(int id)
    {
      var appointment = await _appointmentService.GetAppointmentByIdAsync(id);

      if (appointment == null) return NotFound();

      return Ok(appointment);
    }
    /// <summary>
    /// Create a new appointment
    /// Role: Customer, ClinicOwner
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Customer, ClinicOwner")]
    public async Task<ActionResult<AppointmentDto>> CreateAppointment(AppointmentCreateDto appointmentCreateDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var appointment = await _appointmentService.CreateAppointmentAsync(appointmentCreateDto);

      return CreatedAtAction(nameof(GetAppointment), new { id = appointment.AppointmentID }, appointment);
    }

    /// <summary>
    /// Update an appointment
    /// Role: ClinicOwner
    /// </summary>
    [HttpPut("{id}")]
    [Authorize(Roles = "ClinicOwner")]
    public async Task<IActionResult> UpdateAppointment(int id, AppointmentUpdateDto appointmentUpdateDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var appointment = await _appointmentService.UpdateAppointmentAsync(id, appointmentUpdateDto);

      if (appointment == null) return NotFound();

      return NoContent();
    }

    /// <summary>
    /// Delete an appointment
    /// Role: ClinicOwner
    /// </summary>
    [HttpDelete("{id}")]
    [Authorize(Roles = "ClinicOwner")]
    public async Task<IActionResult> DeleteAppointment(int id)
    {
      var success = await _appointmentService.DeleteAppointmentAsync(id);

      if (!success) return NotFound();

      return NoContent();
    }
  }
}