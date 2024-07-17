using System.Text.Json;
using DentistryRepositories;
using DentistryRepositories.Extensions;
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

    /// <summary>
    /// Get all dentists
    /// Role: ClinicOwner, Admin, Dentist, Customer
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /Dentists
    ///     PARAMS:
    ///         ClinicID: 1 (filter by clinic id)
    ///         OrderBy: clinicAsc
    /// </remarks>

    [HttpGet]
    // [Authorize(Roles = "ClinicOwner, Admin, Customer, Dentist")]
    public async Task<ActionResult<PagedList<DentistDto>>> GetPagedDentists([FromQuery] DentistQueryParams queryParams)
    {
      var dentists = await _dentistService.GetAllDentistsAsync(queryParams);
      Response.Headers.Add("Pagination", JsonSerializer.Serialize(dentists.MetaData));
      return Ok(dentists);
    }

    /// <summary>
    /// Get a dentist by id
    /// Role: ClinicOwner, Dentist, Admin, Customer
    /// </summary>
    [HttpGet("{id}")]
    // [Authorize(Roles = "ClinicOwner,Dentist,Admin,Customer")]
    public async Task<ActionResult<DentistDto>> GetDentistById(int id)
    {
      var dentist = await _dentistService.GetDentistByIdAsync(id);

      if (dentist == null) return NotFound();

      return Ok(dentist);
    }

    // [HttpPost]
    // [Authorize(Roles = "ClinicOwner,Admin")]
    // public async Task<ActionResult<DentistDto>> CreateDentist(DentistCreateDto dentistDto)
    // {
    //   if (!ModelState.IsValid) return BadRequest(ModelState);
    //   var dentist = await _dentistService.AddDentistAsync(dentistDto);

    //   return CreatedAtAction(nameof(GetDentistById), new { id = dentist.DentistId }, dentist);
    // }

    /// <summary>
    /// Update a dentist
    /// Role: ClinicOwner, Admin, Dentist
    /// </summary>
    [HttpPut]
    [Authorize(Roles = "ClinicOwner,Admin,Dentist")]
    public async Task<ActionResult<DentistDto>> UpdateDentist(int id, DentistUpdateDto dentistDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var dentist = await _dentistService.UpdateDentistAsync(id, dentistDto);
      if (dentist == null) return NotFound();

      return CreatedAtAction(nameof(GetDentistById), new { id = dentist.DentistId }, dentist);
    }

    /// <summary>
    /// Delete a dentist
    /// Role: ClinicOwner, Admin, Dentist
    /// </summary>
    [HttpDelete("{id}")]
    [Authorize(Roles = "ClinicOwner,Admin,Dentist")]
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
