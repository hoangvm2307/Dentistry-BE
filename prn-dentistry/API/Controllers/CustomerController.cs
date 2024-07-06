using DentistryRepositories;
using DentistryServices;
using DTOs.CustomerDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace prn_dentistry.API.Controllers
{
  public class CustomerController : BaseApiController
  {
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
      _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
    {
      var customers = await _customerService.GetAllCustomersAsync();
      return Ok(customers);
    }

    [HttpGet("/getCustomersByClinicId/{id}")]
    [Authorize(Roles = "ClinicOwner")]
    public async Task<ActionResult<PaginatedList<CustomerDto>>> GetDentistsByClinicIdAsync(int id, [FromQuery] QueryParams queryParams)
    {
      var customers = await _customerService.GetCustomersByClinicIdAsync(id, queryParams);
      return Ok(customers);
    }
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, ClinicOwner")]
    public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
    {
      var customer = await _customerService.GetCustomerByIdAsync(id);

      if (customer == null) return NotFound();

      return Ok(customer);
    }

    [HttpGet("paged")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<PaginatedList<CustomerDto>>> GetCustomers([FromQuery] QueryParams queryParams)
    {
      var pagedDentists = await _customerService.GetPagedCustomersAsync(queryParams);
      return Ok(pagedDentists);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Customer")]
    public async Task<ActionResult<CustomerDto>> UpdateCustomer(int id, CustomerCreateDto customerUpdateDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var customer = new CustomerDto();

      try
      {
        customer = await _customerService.UpdateCustomerAsync(id, customerUpdateDto);
      }
      catch
      {
        return NotFound();
      }

      return CreatedAtAction(nameof(GetCustomerById), new { id = customer.CustomerID }, customer);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Customer")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
      try
      {
        await _customerService.DeleteCustomerAsync(id);
      }
      catch
      {
        return NotFound();
      }

      return NoContent();
    }
  }
}
