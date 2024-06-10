using DentistryServices;
using DTOs.CustomerDtos;
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

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
    {
      var customer = await _customerService.GetCustomerByIdAsync(id);

      if (customer == null)  return NotFound();
    
      return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> CreateCustomer(CustomerCreateDto customerCreateDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var customer = await _customerService.CreateCustomerAsync(customerCreateDto);

      return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerID }, customer);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CustomerDto>> UpdateCustomer(int id, CustomerCreateDto customerUpdateDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var customer = new CustomerDto();

      try {
        customer = await _customerService.UpdateCustomerAsync(id, customerUpdateDto);
      } catch {
        return NotFound();
      }

      return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerID }, customer);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
      try 
      {
        await _customerService.DeleteCustomerAsync(id);
      } catch {
        return NotFound();
      }

      return NoContent();
    }
  }
}
