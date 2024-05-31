using DentistryServices;
using DTOs.ServiceDto;
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
      if (service == null)
      {
        return NotFound();
      }

      return Ok(service);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceDto>> CreateService(ServiceCreateDto serviceCreateDto)
    {
      var service = await _serviceService.CreateServiceAsync(serviceCreateDto);
      return CreatedAtAction(nameof(GetService), new { id = service.ServiceID }, service);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateService(int id, ServiceUpdateDto serviceUpdateDto)
    {
      var updatedService = await _serviceService.UpdateServiceAsync(id, serviceUpdateDto);
      if (updatedService == null)
      {
        return NotFound();
      }

      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteService(int id)
    {
      var success = await _serviceService.DeleteServiceAsync(id);
      if (!success)
      {
        return NotFound();
      }

      return NoContent();
    }
  }
}
