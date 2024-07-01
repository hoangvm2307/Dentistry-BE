using DentistryServices;
using DTOs.ClinicDtos;
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
    public async Task<ActionResult<IEnumerable<ClinicDto>>> GetAllClinics()
    {
      var clinics = await _clinicService.GetAllClinicsAsync();
      return Ok(clinics);
    }

    [HttpGet("{id}/getById")]
    public async Task<ActionResult<ClinicDto>> GetClinicById(int id)
    {
      var clinic = await _clinicService.GetClinicByIdAsync(id);

      if (clinic == null)  return NotFound();
    
      return Ok(clinic);
    }

    [HttpGet("getFilter")]
    public async Task<ActionResult<IEnumerable<ClinicDto>>> GetClinicByStatus([FromQuery] List<bool> statuses)
    {
      var clinic = await _clinicService.GetClinicsByStatusAsync(statuses);

      if (clinic == null)  return NotFound();
    
      return Ok(clinic);
    }

    [HttpPost]
    public async Task<ActionResult<ClinicDto>> CreateService([FromForm]ClinicCreateDto clinicDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var clinic = await _clinicService.AddClinicAsync(clinicDto);

      return CreatedAtAction(nameof(GetClinicById), new { id = clinic.ClinicID }, clinic);
    }

    [HttpPut]
    public async Task<ActionResult<ClinicDto>> UpdateService(int id, ClinicCreateDto clinicDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var clinic = new ClinicDto();

      try {
        clinic = await _clinicService.UpdateClinicAsync(id, clinicDto);
      } catch {
        return NotFound();
      }

      return CreatedAtAction(nameof(GetClinicById), new { id = clinic.ClinicID }, clinic);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteService(int id)
    {
      try {
        await _clinicService.DeleteClinicAsync(id);
      } catch {
        return NotFound();
      }

      return NoContent();
    }
  }
}
