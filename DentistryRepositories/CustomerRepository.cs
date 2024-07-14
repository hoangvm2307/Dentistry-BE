using System.Linq.Expressions;
using DentistryBusinessObjects;
using DentistryRepositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DentistryRepositories
{
  public class CustomerRepository : ICustomerRepository
  {
    private readonly DBContext _context;


    public CustomerRepository(DBContext context)
    {
      _context = context;
    }

    public async Task AddCustomerAsync(Customer customer)
    {
      await _context.Customers.AddAsync(customer);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteCustomerAsync(int id)
    {
      var customer = await _context.Customers.FindAsync(id);
      if (customer != null)
      {
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
      }
    }

    public async Task<PagedList<Customer>> GetAllCustomersAsync(CustomerQueryParam queryParams)
    {
      var query = _context.Customers
      .Include(c => c.User)
      .Sort(queryParams.OrderBy)
      .Search(queryParams.SearchTerm)
      .Filter(queryParams.ClinicID)
      .AsQueryable();

      return await PagedList<Customer>.ToPagedList(query, queryParams.PageNumber, queryParams.PageSize);

    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
      return await _context.Customers.FindAsync(id);
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
      _context.Entry(customer).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

  }
}