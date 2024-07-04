using System.Linq.Expressions;
using DentistryBusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DentistryRepositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DBContext _context;
    private readonly IBaseRepository<Customer> _baseRepository;

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

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
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

        public Task<PaginatedList<Customer>> GetPagedCustomersAsync(int pageIndex, int pageSize, Expression<Func<Customer, bool>> filter, Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy)
        {
            return _baseRepository.GetPagedAsync(pageIndex, pageSize, filter, orderBy);
        }
    }
}