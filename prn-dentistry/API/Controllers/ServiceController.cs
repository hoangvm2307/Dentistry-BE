using DentistryRepositories;
using DentistryServices;
using DTOs.ServiceDtos;
using Microsoft.AspNetCore.Mvc;


namespace prn_dentistry.API.Controllers
{
  public class ServiceController : BaseApiController
  {
    private readonly IServiceService _serviceService;

    public ServiceController(IServiceService serviceService)
    {
      _serviceService = serviceService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceDto>>> GetAllServices()
    {
      var services = await _serviceService.GetAllServicesAsync();
      return Ok(services);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceDto>> GetService(int id)
    {
      var service = await _serviceService.GetServiceByIdAsync(id);

      if (service == null) return NotFound();

      return Ok(service);
    }
    
    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedList<ServiceDto>>> GetPagedClinics([FromQuery] QueryParams queryParams)
    {
      var pagedDentists = await _serviceService.GetPagedServicesAsync(queryParams);
      return Ok(pagedDentists);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceDto>> CreateService(ServiceCreateDto serviceCreateDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var service = await _serviceService.CreateServiceAsync(serviceCreateDto);

      return CreatedAtAction(nameof(GetService), new { id = service.ServiceID }, service);
    }

    [HttpPost("batch")]
    public async Task<ActionResult<IEnumerable<ServiceDto>>> BatchCreateServices(BatchServiceCreateDto batchServiceCreateDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var createdServices = new List<ServiceDto>();

      foreach (var serviceCreateDto in batchServiceCreateDto.Services)
      {
        var service = await _serviceService.CreateServiceAsync(serviceCreateDto);
        createdServices.Add(service);
      }

      return Ok(createdServices);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateService(int id, ServiceUpdateDto serviceUpdateDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var updatedService = await _serviceService.UpdateServiceAsync(id, serviceUpdateDto);

      if (updatedService == null) return NotFound();

      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteService(int id)
    {
      var success = await _serviceService.DeleteServiceAsync(id);

      if (!success) return NotFound();

      return NoContent();
    }
  }
}
