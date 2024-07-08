using System.Text.Json;
using DentistryRepositories.Extensions;
using DentistryServices;
using DTOs.TreatmentPlanDtos;
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TreatmentPlanDto>>> GetAllTreatmentPlans([FromQuery] TreatmentQueryParams queryParams)
    {
      var treatmentPlans = await _treatmentPlanService.GetAllTreatmentPlansAsync(queryParams);
      Response.Headers.Add("Pagination", JsonSerializer.Serialize(treatmentPlans.MetaData));
      return Ok(treatmentPlans);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TreatmentPlanDto>> GetTreatmentPlan(int id)
    {
      var treatmentPlan = await _treatmentPlanService.GetTreatmentPlanByIdAsync(id);

      if (treatmentPlan == null)
        return NotFound();

      return Ok(treatmentPlan);
    }

    [HttpPost]
    public async Task<ActionResult<TreatmentPlanDto>> CreateTreatmentPlan(TreatmentPlanCreateDto treatmentPlanCreateDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var treatmentPlan = await _treatmentPlanService.CreateTreatmentPlanAsync(treatmentPlanCreateDto);

      return CreatedAtAction(nameof(GetTreatmentPlan), new { id = treatmentPlan.PlanID }, treatmentPlan);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTreatmentPlan(int id, TreatmentPlanUpdateDto treatmentPlanUpdateDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var updatedTreatmentPlan = await _treatmentPlanService.UpdateTreatmentAsync(id, treatmentPlanUpdateDto);

      if (updatedTreatmentPlan == null)
        return NotFound();

      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTreatmentPlan(int id)
    {
      var success = await _treatmentPlanService.DeleteTreatmentPlanAsync(id);

      if (!success) return NotFound();

      return NoContent();
    }
  }
}