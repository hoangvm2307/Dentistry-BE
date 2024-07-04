using System.Linq.Expressions;
using DentistryBusinessObjects;

namespace DentistryRepositories
{
  public interface ICustomerRepository
  {
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<Customer> GetCustomerByIdAsync(int id);
    Task AddCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(int id);
    Task<PaginatedList<Customer>> GetPagedCustomersAsync(
            int pageIndex,
            int pageSize,
            Expression<Func<Customer, bool>> filter,
            Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy);
  }
}