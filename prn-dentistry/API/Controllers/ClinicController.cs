using DentistryRepositories;
using DentistryServices;
using DTOs.ClinicDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace prn_dentistry.API.Controllers
{
  [Authorize]
  public class ClinicController : BaseApiController
  {
    private readonly IClinicService _clinicService;

    public ClinicController(IClinicService clinicService)
    {
      _clinicService = clinicService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin,Customer")]
    public async Task<ActionResult<IEnumerable<ClinicDto>>> GetAllClinics()
    {
      var clinics = await _clinicService.GetAllClinicsAsync();
      return Ok(clinics);
    }

    [HttpGet("{id}/getById")]
    [Authorize]
    public async Task<ActionResult<ClinicDto>> GetClinicById(int id)
    {
      var clinic = await _clinicService.GetClinicByIdAsync(id);

      if (clinic == null) return NotFound();

      return Ok(clinic);
    }

    [HttpGet("getFilter")]
    public async Task<ActionResult<IEnumerable<ClinicDto>>> GetClinicByStatus([FromQuery] List<bool> statuses)
    {
      var clinic = await _clinicService.GetClinicsByStatusAsync(statuses);

      if (clinic == null) return NotFound();

      return Ok(clinic);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedList<ClinicDto>>> GetPagedClinics([FromQuery] QueryParams queryParams)
    {
      var pagedDentists = await _clinicService.GetPagedClinicsAsync(queryParams);
      return Ok(pagedDentists);
    }
    [HttpPost]
    [Authorize(Roles = "ClinicOwner")]
    public async Task<ActionResult<ClinicDto>> CreateClinic([FromBody] ClinicCreateDto clinicDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var clinic = await _clinicService.AddClinicAsync(clinicDto);

      return CreatedAtAction(nameof(GetClinicById), new { id = clinic.ClinicID }, clinic);
    }

    [HttpPut]
    [Authorize(Roles = "ClinicOwner")]
    public async Task<ActionResult<ClinicDto>> UpdateClinic(int id, ClinicCreateDto clinicDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var clinic = new ClinicDto();

      try
      {
        clinic = await _clinicService.UpdateClinicAsync(id, clinicDto);
      }
      catch
      {
        return NotFound();
      }

      return CreatedAtAction(nameof(GetClinicById), new { id = clinic.ClinicID }, clinic);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "ClinicOwner")]

    public async Task<IActionResult> DeleteClinic(int id)
    {
      try
      {
        await _clinicService.DeleteClinicAsync(id);
      }
      catch
      {
        return NotFound();
      }

      return NoContent();
    }
  }
}
