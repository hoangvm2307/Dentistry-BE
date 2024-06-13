using DentistryServices;
using DTOs.DentistDtos;
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
    public async Task<ActionResult<IEnumerable<DentistDto>>> GetAllDentists()
    {
      var dentists = await _dentistService.GetAllDentistsAsync();
      return Ok(dentists);
    }

    [HttpGet("/getDentistByClinicId/{id}")]
    public async Task<ActionResult<IEnumerable<DentistDto>>> GetDentistsByClinicIdAsync(int id)
    {
      var dentists = await _dentistService.GetDentistsByClinicIdAsync(id);
      return Ok(dentists);
    }

    [HttpGet("/getById/{id}")]
    public async Task<ActionResult<DentistDto>> GetDentistById(int id)
    {
      var dentist = await _dentistService.GetDentistByIdAsync(id);

      if (dentist == null)  return NotFound();
    
      return Ok(dentist);
    }

    [HttpGet("getFilter")]
    public async Task<ActionResult<IEnumerable<DentistDto>>> GetDentistsByClinicIdAndStatusAsync([FromQuery] List<int> ids,[FromQuery] List<bool> statuses)
    {
      var dentist = await _dentistService.GetDentistsByClinicIdAndStatusAsync(ids, statuses);

      if (dentist == null)  return NotFound();
    
      return Ok(dentist);
    }

    [HttpPost]
    public async Task<ActionResult<DentistDto>> CreateService(DentistCreateDto dentistDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var dentist = await _dentistService.AddDentistAsync(dentistDto);

      return CreatedAtAction(nameof(GetDentistById), new { id = dentist.DentistId }, dentist);
    }

    [HttpPut]
    public async Task<ActionResult<DentistDto>> UpdateService(int id, DentistCreateDto dentistDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var dentist = new DentistDto();

      try {
        dentist = await _dentistService.UpdateDentistAsync(id, dentistDto);
      } catch {
        return NotFound();
      }

      return CreatedAtAction(nameof(GetDentistById), new { id = dentist.DentistId }, dentist);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteService(int id)
    {
      try {
        await _dentistService.DeleteDentistAsync(id);
      } catch {
        return NotFound();
      }

      return NoContent();
    }
  }
}
