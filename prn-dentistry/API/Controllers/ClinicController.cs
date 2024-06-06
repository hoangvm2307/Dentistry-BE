using DentistryServices;
using DTOs.ClinicDtos;
using DTOs.DentistDtos;
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
    public async Task<ActionResult<List<ClinicDto>>> GetAllClinics()
    {
      var clinics = await _clinicService.GetAllClinicsAsync();
      return Ok(clinics);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClinicDto>> GetClinicById(int id)
    {
      var clinic = await _clinicService.GetClinicByIdAsync(id);

      if (clinic == null)  return NotFound();
    
      return Ok(clinic);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClinicDto>> GetClinicByStatus(List<bool> statuses)
    {
      var clinic = await _clinicService.GetClinicsByStatusAsync(statuses);

      if (clinic == null)  return NotFound();
    
      return Ok(clinic);
    }

    [HttpPost]
    public async Task<ActionResult<ClinicDto>> CreateService(ClinicCreateDto clinicDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var clinic = await _clinicService.AddClinicAsync(clinicDto);

      return CreatedAtAction(nameof(GetClinicById), new { id = clinic.ClinicID }, clinic);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateService(int id, ClinicCreateDto clinicDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      try {
        await _clinicService.UpdateClinicAsync(id, clinicDto);
      } catch {
        return NotFound();
      }

      return NoContent();
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
