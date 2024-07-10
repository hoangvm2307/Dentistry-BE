using DentistryRepositories;
using DentistryRepositories.Extensions;
using DTOs.CustomerDtos;

namespace DentistryServices
{
  public interface ICustomerService
  {
    Task<PagedList<CustomerDto>> GetAllCustomersAsync(CustomerQueryParam queryParams);
    Task<CustomerDto> GetCustomerByIdAsync(int id);
    Task<CustomerDto> CreateCustomerAsync(CustomerCreateDto customer);
    Task<CustomerDto> UpdateCustomerAsync(int id, CustomerUpdateDto customer);
    Task DeleteCustomerAsync(int id);
  }
}