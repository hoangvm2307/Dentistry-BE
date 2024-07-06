using DentistryRepositories;
using DentistryServices;
using DTOs.DentistDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace prn_dentistry.API.Controllers
{
  public class DentistController : BaseApiController
  {
    private readonly IDentistService _dentistService;

    public DentistController(IDentistService dentistService)
    {
      _dentistService = dentistService;
    }

    [HttpGet]
    [Authorize(Roles = "ClinicOwner")]
    public async Task<ActionResult<IEnumerable<DentistDto>>> GetAllDentists([FromQuery] Dictionary<string, int> param)
    {
      var dentists = await _dentistService.GetAllDentistsAsync();

      return Ok(dentists);
    }
    [HttpGet("paged")]
    [Authorize(Roles = "ClinicOwner")]
    public async Task<ActionResult<PaginatedList<DentistDto>>> GetPagedDentists([FromQuery] QueryParams queryParams)
    {
      var pagedDentists = await _dentistService.GetPagedDentistsAsync(queryParams);
      return Ok(pagedDentists);
    }

    [HttpGet("/getDentistByClinicId/{id}")]
    [Authorize(Roles = "ClinicOwner")]
    public async Task<ActionResult<PaginatedList<DentistDto>>> GetDentistsByClinicIdAsync(int id, [FromQuery] QueryParams queryParams)
    {
      var dentists = await _dentistService.GetDentistsByClinicIdAsync(id, queryParams);
      return Ok(dentists);
    }

    [HttpGet("/getById/{id}")]
    [Authorize(Roles = "ClinicOwner,Customer,Dentist")]
    public async Task<ActionResult<DentistDto>> GetDentistById(int id)
    {
      var dentist = await _dentistService.GetDentistByIdAsync(id);

      if (dentist == null) return NotFound();

      return Ok(dentist);
    }

    [HttpGet("getFilter")]
    public async Task<ActionResult<IEnumerable<DentistDto>>> GetDentistsByClinicIdAndStatusAsync([FromQuery] List<int> ids, [FromQuery] List<bool> statuses)
    {
      var dentist = await _dentistService.GetDentistsByClinicIdAndStatusAsync(ids, statuses);

      if (dentist == null) return NotFound();

      return Ok(dentist);
    }

    [HttpPost]
    [Authorize(Roles = "ClinicOwner")]
    public async Task<ActionResult<DentistDto>> CreateDentist(DentistCreateDto dentistDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var dentist = await _dentistService.AddDentistAsync(dentistDto);

      return CreatedAtAction(nameof(GetDentistById), new { id = dentist.DentistId }, dentist);
    }

    [HttpPut]
    [Authorize(Roles = "ClinicOwner")]
    public async Task<ActionResult<DentistDto>> UpdateDentist(int id, DentistCreateDto dentistDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var dentist = new DentistDto();

      try
      {
        dentist = await _dentistService.UpdateDentistAsync(id, dentistDto);
      }
      catch
      {
        return NotFound();
      }

      return CreatedAtAction(nameof(GetDentistById), new { id = dentist.DentistId }, dentist);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "ClinicOwner,Admin")]
    public async Task<IActionResult> DeleteDentist(int id)
    {
      try
      {
        await _dentistService.DeleteDentistAsync(id);
      }
      catch
      {
        return NotFound();
      }

      return NoContent();
    }
  }
}
