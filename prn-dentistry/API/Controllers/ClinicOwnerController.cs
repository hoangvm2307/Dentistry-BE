using DentistryServices;
using DTOs.ClinicOwnerDtos;
using Microsoft.AspNetCore.Mvc;


namespace prn_dentistry.API.Controllers
{
  public class ClinicOwnerController : BaseApiController
  {
    private readonly IClinicOwnerService _clinicOwnerService;

    public ClinicOwnerController(IClinicOwnerService clinicOwnerService)
    {
      _clinicOwnerService = clinicOwnerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClinicOwnerDto>>> GetAllClinicOwners()
    {
      var clinicOwners = await _clinicOwnerService.GetAllClinicOwnersAsync();
      return Ok(clinicOwners);
    }

    [HttpGet("{id}/getById")]
    public async Task<ActionResult<ClinicOwnerDto>> GetClinicOwner(int id)
    {
      var clinicOwner = await _clinicOwnerService.GetClinicOwnerByIdAsync(id);

      if (clinicOwner == null)  return NotFound();
    
      return Ok(clinicOwner);
    }

    [HttpGet("getFilter")]
    public async Task<ActionResult<IEnumerable<ClinicOwnerDto>>> GetClinicByStatus([FromQuery] List<int> ids,[FromQuery] List<bool> statuses)
    {
      var clinicOwner = await _clinicOwnerService.GetClinicOwnersByClinicIdAndStatusAsync(ids, statuses);

      if (clinicOwner == null)  return NotFound();
    
      return Ok(clinicOwner);
    }

    [HttpPost]
    public async Task<ActionResult<ClinicOwnerDto>> CreateClinicOwner(ClinicOwnerCreateDto clinicOwnerCreateDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var clinicOwner = await _clinicOwnerService.CreateClinicOwnerAsync(clinicOwnerCreateDto);

      return CreatedAtAction(nameof(GetClinicOwner), new { id = clinicOwner.OwnerID }, clinicOwner);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ClinicOwnerDto>> UpdateClinicOwner(int id, ClinicOwnerCreateDto clinicOwnerUpdateDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var clinicOwner = new ClinicOwnerDto();

      try {
        clinicOwner = await _clinicOwnerService.UpdateClinicOwnerAsync(id, clinicOwnerUpdateDto);
      } catch {
        return NotFound();
      }

      return CreatedAtAction(nameof(GetClinicOwner), new { id = clinicOwner.OwnerID }, clinicOwner);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClinicOwner(int id)
    {
      try 
      {
        await _clinicOwnerService.DeleteClinicOwnerAsync(id);
      } catch {
        return NotFound();
      }

      return NoContent();
    }
  }
}
