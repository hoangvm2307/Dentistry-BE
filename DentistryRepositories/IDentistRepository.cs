using System.Linq.Expressions;
using DentistryBusinessObjects;

namespace DentistryRepositories
{
  public interface IDentistRepository
  {
    Task<IEnumerable<Dentist>> GetAllDentistsAsync();
    Task<Dentist> GetDentistByIdAsync(int id);
    Task AddDentistAsync(Dentist dentist);
    Task UpdateDentistAsync(Dentist dentist);
    Task DeleteDentistAsync(int id);
    Task<PaginatedList<Dentist>> GetPagedDentistsAsync(
            int pageIndex,
            int pageSize,
            Expression<Func<Dentist, bool>> filter = null,
            Func<IQueryable<Dentist>, IOrderedQueryable<Dentist>> orderBy = null);
  }
}