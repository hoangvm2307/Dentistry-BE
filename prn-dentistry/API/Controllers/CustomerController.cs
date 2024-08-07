using System.Text.Json;
using DentistryRepositories.Extensions;
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

    /// <summary>
    /// Get all customers
    /// Role: Admin, ClinicOwner, Dentist
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /Customers
    ///     PARAMS:
    ///         ClinicId: 1
    ///         OrderBy: nameAsc/_(nameDesc)
    /// </remarks>
    [HttpGet]
    [Authorize(Roles = "Admin,ClinicOwner,Dentist")]
    public async Task<ActionResult<PagedList<CustomerDto>>> GetAllCustomers([FromQuery] CustomerQueryParam queryParams)
    {
      var customers = await _customerService.GetAllCustomersAsync(queryParams);
      Response.Headers.Add("Pagination", JsonSerializer.Serialize(customers.MetaData));
      return Ok(customers);
    }

    /// <summary>
    /// Get a customer by id
    /// Role: Admin, ClinicOwner, Customer
    /// </summary>
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, ClinicOwner,Customer")]
    public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
    {
      var customer = await _customerService.GetCustomerByIdAsync(id);

      if (customer == null) return NotFound();

      return Ok(customer);
    }

    /// <summary>
    /// Update a customer
    /// Role: Customer, Admin, ClinicOwner
    /// </summary>
    [HttpPut("{id}")]
    [Authorize(Roles = "Customer,Admin,ClinicOwner")]
    public async Task<ActionResult<CustomerDto>> UpdateCustomer(int id, CustomerUpdateDto customerUpdateDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var customer = await _customerService.UpdateCustomerAsync(id, customerUpdateDto);
      if (customer == null) return NotFound();


      return CreatedAtAction(nameof(GetCustomerById), new { id = customer.CustomerID }, customer);
    }

    /// <summary>
    /// Delete a customer
    /// Role: Admin, Customer, ClinicOwner
    /// </summary>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Customer,ClinicOwner")]
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
