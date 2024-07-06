using System.Linq.Expressions;
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

    public async Task<PaginatedList<CustomerDto>> GetCustomersByClinicIdAsync(int id, QueryParams queryParams)
    {
      Expression<Func<Customer, bool>> filterExpression = e => e.Appointments.Any(a => a.Dentist.ClinicID == id);
      return await GetCustomersAsync(filterExpression, queryParams);
    }
    public async Task<PaginatedList<CustomerDto>> GetPagedCustomersAsync(QueryParams queryParams)
    {
      Expression<Func<Customer, bool>> filterExpression = null;
      return await GetCustomersAsync(filterExpression, queryParams);
    }

    #region Private
    private async Task<PaginatedList<CustomerDto>> GetCustomersAsync(Expression<Func<Customer, bool>> filterExpression, QueryParams queryParams)
    {
      if (!string.IsNullOrEmpty(queryParams.Search))
      {
        string searchLower = queryParams.Search.ToLower();
        Expression<Func<Customer, bool>> searchExpression = e => e.Name.ToLower().Contains(searchLower);
        if (filterExpression != null)
        {
          filterExpression = filterExpression.AndAlso(searchExpression);
        }
        else
        {
          filterExpression = searchExpression;
        }
      }
      Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy = null;
      if (queryParams.Sort != null)
      {
        switch (queryParams.Sort.Key)
        {
          case "name":
            orderBy = q => queryParams.Sort.Value == 1 ? q.OrderByDescending(e => e.Name) : q.OrderBy(e => e.Name);
            break;
          case "status":
            orderBy = q => queryParams.Sort.Value == 1 ? q.OrderByDescending(e => e.Status) : q.OrderBy(e => e.Status);
            break;
          default:
            orderBy = q => q.OrderBy(e => e.CustomerID); // Default sort by CustomerID
            break;
        }
      }
      else
      {
        orderBy = q => q.OrderBy(e => e.CustomerID); // Default sort by CustomerID
      }

      var pagedCustomers = await _customerRepository.GetPagedCustomersAsync(queryParams.PageIndex, queryParams.PageSize, filterExpression, orderBy);
      return new PaginatedList<CustomerDto>(
          _mapper.Map<List<CustomerDto>>(pagedCustomers),
          pagedCustomers.Count,
          pagedCustomers.PageIndex,
          queryParams.PageSize
      );
    }
    #endregion
  }
}