using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories;
using DTOs.CustomerDtos;


namespace DentistryServices
{
  public class CustomerService : ICustomerService
  {
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
      _customerRepository = customerRepository;
      _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
    {
      var customers = await _customerRepository.GetAllCustomersAsync();
      return _mapper.Map<IEnumerable<CustomerDto>>(customers);
    }

    public async Task<CustomerDto> GetCustomerByIdAsync(int id)
    {
      var customer = await _customerRepository.GetCustomerByIdAsync(id);
      return _mapper.Map<CustomerDto>(customer);
    }

    private async Task<IEnumerable<CustomerDto>> GetCustomersByStatusAsync(List<bool> statuses)
    {
      var customer = await _customerRepository.GetAllCustomersAsync();

      if (statuses != null){
        customer = customer.Where(customer => statuses.Contains(customer.Status));
      }
      
      return _mapper.Map<IEnumerable<CustomerDto>>(customer);
    }

    public async Task<CustomerDto> CreateCustomerAsync(CustomerCreateDto customerCreateDto)
    {
      var customer = _mapper.Map<Customer>(customerCreateDto);
      await _customerRepository.AddCustomerAsync(customer);
      return _mapper.Map<CustomerDto>(customer);
    }

    public async Task<CustomerDto> UpdateCustomerAsync(int id, CustomerCreateDto customerUpdateDto)
    {
      var customer = await _customerRepository.GetCustomerByIdAsync(id);
      if (customer == null)
      {
        throw new NullReferenceException("Customer object is null.");
      }

      _mapper.Map(customerUpdateDto, customer);
      await _customerRepository.UpdateCustomerAsync(customer);
      return _mapper.Map<CustomerDto>(customer);
    }

    public async Task DeleteCustomerAsync(int id)
    {
      var customer = await _customerRepository.GetCustomerByIdAsync(id);
      if (customer == null)
      {
        throw new NullReferenceException("Customer object is null.");
      }

      await _customerRepository.DeleteCustomerAsync(id);
    }
  }
}