using System.Text.Json;
using DentistryRepositories;
using DentistryRepositories.Extensions;
using DentistryServices;
using DTOs.ClinicDtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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

    /// <summary>
    /// Get all customers
    /// Role: Admin, Customer, ClinicOwner
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /Customers
    ///     PARAMS:
    ///         Status: active/unactive
    ///         OrderBy: nameAsc/_(nameDesc)
    /// </remarks>
    [HttpGet]
    // [Authorize(Roles = "Admin,Customer, ClinicOwner")]
    public async Task<ActionResult<PagedList<ClinicDto>>> GetAllClinics([FromQuery] ClinicQueryParams queryParams)
    {
      var clinics = await _clinicService.GetAllClinicsAsync(queryParams);
      Response.Headers.Add("Pagination", JsonSerializer.Serialize(clinics.MetaData));
      return Ok(clinics);
    }

    /// <summary>
    /// Get a clinic by id
    /// Role: ClinicOwner, Admin, Customer
    /// </summary>
    [HttpGet("{id}")]
    // [Authorize(Roles = "Admin, Customer, ClinicOwner")]
    public async Task<ActionResult<ClinicDto>> GetClinicById(int id)
    {
      var clinic = await _clinicService.GetClinicByIdAsync(id);

      if (clinic == null) return NotFound();

      return Ok(clinic);
    }

    /// <summary>
    /// Create a clinic
    /// Role: ClinicOwner, Admin
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Admin,ClinicOwner")]
    public async Task<ActionResult<ClinicDto>> CreateClinic([FromBody] ClinicCreateDto clinicDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var clinic = await _clinicService.AddClinicAsync(clinicDto);

      return CreatedAtAction(nameof(GetClinicById), new { id = clinic.ClinicID }, clinic);
    }

    /// <summary>
    /// Update a clinic
    /// Role: ClinicOwner, Admin
    /// </summary>
    [HttpPut]
    [Authorize(Roles = "Admin,ClinicOwner")]
    public async Task<ActionResult<ClinicDto>> UpdateClinic(int id, ClinicUpdateDto clinicDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var clinic = await _clinicService.UpdateClinicAsync(id, clinicDto);
      if (clinic == null) return NotFound();

      return CreatedAtAction(nameof(GetClinicById), new { id = clinic.ClinicID }, clinic);
    }

    /// <summary>
    /// Delete a clinic
    /// Role: ClinicOwner, Admin
    /// </summary>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,ClinicOwner")]

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
