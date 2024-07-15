using System.Text.Json;
using DentistryRepositories.Extensions;
using DentistryServices;
using DTOs.TreatmentPlanDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace prn_dentistry.API.Controllers
{
  public class TreatmentPlanController : BaseApiController
  {
    private readonly ITreatmentPlanService _treatmentPlanService;

    public TreatmentPlanController(ITreatmentPlanService treatmentPlanService)
    {
      _treatmentPlanService = treatmentPlanService;
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
    ///         ClinicID: 1(filter by clinic id)
    ///         DentistID: 1 (filter by dentist id)
    ///         CustomerID: 1(filter by customer id)
    ///         OrderBy: clinicAsc
    /// </remarks>
    [HttpGet]
    [Authorize(Roles = "Dentist,ClinicOwner")]
    public async Task<ActionResult<IEnumerable<TreatmentPlanDto>>> GetAllTreatmentPlans([FromQuery] TreatmentQueryParams queryParams)
    {
      var treatmentPlans = await _treatmentPlanService.GetAllTreatmentPlansAsync(queryParams);
      Response.Headers.Add("Pagination", JsonSerializer.Serialize(treatmentPlans.MetaData));
      return Ok(treatmentPlans);
    }
    /// <summary>
    /// Get a treatment plan by id
    /// Role: Dentist, ClinicOwner
    /// </summary>
    [HttpGet("{id}")]
    [Authorize(Roles = "Dentist,ClinicOwner")]
    public async Task<ActionResult<TreatmentPlanDto>> GetTreatmentPlan(int id)
    {
      var treatmentPlan = await _treatmentPlanService.GetTreatmentPlanByIdAsync(id);

      if (treatmentPlan == null)
        return NotFound();

      return Ok(treatmentPlan);
    }
    /// <summary>
    /// Create a treatment plan
    /// Role: Dentist 
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Dentist")]
    public async Task<ActionResult<TreatmentPlanDto>> CreateTreatmentPlan(TreatmentPlanCreateDto treatmentPlanCreateDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var treatmentPlan = await _treatmentPlanService.CreateTreatmentPlanAsync(treatmentPlanCreateDto);

      return CreatedAtAction(nameof(GetTreatmentPlan), new { id = treatmentPlan.PlanID }, treatmentPlan);
    }
    /// <summary>
    /// Update a treatment plan
    /// Role: Dentist 
    /// </summary>
    [HttpPut("{id}")]
    [Authorize(Roles = "Dentist")]
    public async Task<IActionResult> UpdateTreatmentPlan(int id, TreatmentPlanUpdateDto treatmentPlanUpdateDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var updatedTreatmentPlan = await _treatmentPlanService.UpdateTreatmentAsync(id, treatmentPlanUpdateDto);

      if (updatedTreatmentPlan == null)
        return NotFound();

      return NoContent();
    }
    /// <summary>
    /// Delete a treatment plan
    /// Role: Dentist 
    /// </summary>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Dentist")]
    public async Task<IActionResult> DeleteTreatmentPlan(int id)
    {
      var success = await _treatmentPlanService.DeleteTreatmentPlanAsync(id);

      if (!success) return NotFound();

      return NoContent();
    }
  }
}