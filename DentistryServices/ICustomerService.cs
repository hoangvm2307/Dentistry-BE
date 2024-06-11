using DTOs.CustomerDtos;

namespace DentistryServices
{
    public interface ICustomerService
  {
    Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
    Task<CustomerDto> GetCustomerByIdAsync(int id);
    Task<CustomerDto> CreateCustomerAsync(CustomerCreateDto customer);
    Task<CustomerDto> UpdateCustomerAsync(int id, CustomerCreateDto customer);
    Task DeleteCustomerAsync(int id);
  }
}