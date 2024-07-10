using System.Text.Json;
using DentistryRepositories;
using DentistryRepositories.Extensions;
using DentistryServices;
using DTOs.ClinicDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace prn_dentistry.API.Controllers
{

  public class ClinicController : BaseApiController
  {
    private readonly IClinicService _clinicService;

    public ClinicController(IClinicService clinicService)
    {
      _clinicService = clinicService;
    }

    [HttpGet]
    // [Authorize(Roles = "Admin,Customer")]
    public async Task<ActionResult<PagedList<ClinicDto>>> GetAllClinics([FromQuery] ClinicQueryParams queryParams)
    {
      var clinics = await _clinicService.GetAllClinicsAsync(queryParams);
      Response.Headers.Add("Pagination", JsonSerializer.Serialize(clinics.MetaData));
      return Ok(clinics);
    }

    [HttpGet("{id}")]
    // [Authorize]
    public async Task<ActionResult<ClinicDto>> GetClinicById(int id)
    {
      var clinic = await _clinicService.GetClinicByIdAsync(id);

      if (clinic == null) return NotFound();

      return Ok(clinic);
    }

    [HttpPost]
    // [Authorize(Roles = "ClinicOwner")]
    public async Task<ActionResult<ClinicDto>> CreateClinic([FromBody] ClinicCreateDto clinicDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var clinic = await _clinicService.AddClinicAsync(clinicDto);

      return CreatedAtAction(nameof(GetClinicById), new { id = clinic.ClinicID }, clinic);
    }

    [HttpPut]
    // [Authorize(Roles = "ClinicOwner")]
    public async Task<ActionResult<ClinicDto>> UpdateClinic(int id, ClinicUpdateDto clinicDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var clinic = await _clinicService.UpdateClinicAsync(id, clinicDto);
      if (clinic == null) return NotFound();

      return CreatedAtAction(nameof(GetClinicById), new { id = clinic.ClinicID }, clinic);
    }

    [HttpDelete("{id}")]
    // [Authorize(Roles = "ClinicOwner")]

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
