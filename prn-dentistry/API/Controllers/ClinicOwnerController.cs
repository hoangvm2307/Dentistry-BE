using System.Text.Json;
using DentistryRepositories;
using DentistryRepositories.Extensions;
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
    public async Task<ActionResult<PagedList<ClinicOwnerDto>>> GetAllClinicOwners([FromQuery] ClinicOwnerQueryParams queryParams)
    {
      var clinicOwners = await _clinicOwnerService.GetAllClinicOwnersAsync(queryParams);
      Response.Headers.Add("Pagination", JsonSerializer.Serialize(clinicOwners.MetaData));
      return Ok(clinicOwners);
    }

    [HttpGet("getById/{id}")]
    public async Task<ActionResult<ClinicOwnerDto>> GetClinicOwner(int id)
    {
      var clinicOwner = await _clinicOwnerService.GetClinicOwnerByIdAsync(id);

      if (clinicOwner == null) return NotFound();

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
    public async Task<ActionResult<ClinicOwnerDto>> UpdateClinicOwner(int id, ClinicOwnerUpdateDto clinicOwnerUpdateDto)
    {
       if (!ModelState.IsValid) return BadRequest(ModelState);
      var clinicOwner = await _clinicOwnerService.UpdateClinicOwnerAsync(id, clinicOwnerUpdateDto);
      if (clinicOwner == null) return NotFound();

      return CreatedAtAction(nameof(GetClinicOwner), new { id = clinicOwner.OwnerID }, clinicOwner);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClinicOwner(int id)
    {
      try
      {
        await _clinicOwnerService.DeleteClinicOwnerAsync(id);
      }
      catch
      {
        return NotFound();
      }

      return NoContent();
    }
  }
}
