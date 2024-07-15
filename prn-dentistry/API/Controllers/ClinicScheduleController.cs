
using DentistryRepositories.Extensions;
using DentistryServices;
using DTOs.ClinicScheduleDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace prn_dentistry.API.Controllers
{
  public class ClinicScheduleController : BaseApiController
  {
    private readonly IClinicScheduleService _clinicScheduleService;

    public ClinicScheduleController(IClinicScheduleService clinicScheduleService)
    {
      _clinicScheduleService = clinicScheduleService;
    }

    /// <summary>
    /// Get all clinic schedules
    /// Role: Dentist, ClinicOwner
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /ClinicSchedules
    ///     PARAMS:
    ///         Date: 2024/07/11
    ///         ViewType: available/unavailable
    ///         OrderBy: clinicAsc
    /// </remarks>
    [HttpGet]
    [Authorize(Roles = "Dentist,ClinicOwner")]
    public async Task<ActionResult<IEnumerable<ClinicScheduleDto>>> GetAllClinicSchedules([FromQuery] ClinicScheduleParams queryParams)
    {
      var clinicSchedules = await _clinicScheduleService.GetAllClinicSchedulesAsync(queryParams);
      return Ok(clinicSchedules);
    }

    /// <summary>
    /// Get a clinic schedule by id
    /// Role: Dentist, ClinicOwner
    /// </summary>
    [HttpGet("{id}")]
    [Authorize(Roles = "Dentist,ClinicOwner")]
    public async Task<ActionResult<ClinicScheduleDto>> GetClinicSchedule(int id)
    {
      var clinicSchedule = await _clinicScheduleService.GetClinicScheduleByIdAsync(id);

      if (clinicSchedule == null) return NotFound();

      return Ok(clinicSchedule);
    }

    /// <summary>
    /// Create a clinic schedule 
    /// Role: ClinicOwner
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "ClinicOwner")]
    public async Task<ActionResult<ClinicScheduleDto>> CreateClinicSchedule(ClinicScheduleCreateDto clinicScheduleCreateDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var clinicSchedule = await _clinicScheduleService.CreateClinicScheduleAsync(clinicScheduleCreateDto);

      return CreatedAtAction(nameof(GetClinicSchedule), new { id = clinicSchedule.ScheduleID }, clinicSchedule);
    }

    /// <summary>
    /// Batch create clinic schedules
    /// Role: ClinicOwner
    /// </summary>
    [HttpPost("batch")]
    [Authorize(Roles = "ClinicOwner")]
    public async Task<ActionResult<IEnumerable<ClinicScheduleDto>>> BatchCreateServices(BatchClinicScheduleCreateDto batchServiceCreateDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var createdServices = new List<ClinicScheduleDto>();

      foreach (var clinicScheduleCreateDto in batchServiceCreateDto.ClinicSchedules)
      {
        var service = await _clinicScheduleService.CreateClinicScheduleAsync(clinicScheduleCreateDto);
        createdServices.Add(service);
      }

      return Ok(createdServices);
    }

    /// <summary>
    /// Update a clinic schedule 
    /// Role: ClinicOwner
    /// </summary>
    [HttpPut("{id}")]
    [Authorize(Roles = "ClinicOwner")]
    public async Task<IActionResult> UpdateClinicSchedule(int id, ClinicScheduleUpdateDto clinicScheduleUpdateDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var updatedClinicSchedule = await _clinicScheduleService.UpdateClinicScheduleAsync(id, clinicScheduleUpdateDto);

      if (updatedClinicSchedule == null) return NotFound();

      return NoContent();
    }

    /// <summary>
    /// Delete a clinic schedule 
    /// Role: ClinicOwner
    /// </summary>
    [HttpDelete("{id}")]
    [Authorize(Roles = "ClinicOwner")]
    public async Task<IActionResult> DeleteClinicSchedule(int id)
    {
      var result = await _clinicScheduleService.DeleteClinicScheduleAsync(id);

      if (!result) return NotFound();

      return NoContent();
    }
  }
}