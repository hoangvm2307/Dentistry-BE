using System.Linq.Expressions;
using DentistryBusinessObjects;
using DentistryRepositories.Extensions;

namespace DentistryRepositories
{
  public interface IDentistRepository
  {
    Task<PagedList<Dentist>> GetAllAsync(DentistQueryParams queryParams);
    Task<PagedList<Dentist>> GetAllAsync(SearchParams searchParams);
    Task<Dentist> GetDentistByIdAsync(int id);
    Task AddDentistAsync(Dentist dentist);
    Task UpdateDentistAsync(Dentist dentist);
    Task DeleteDentistAsync(int id);
  
  }
}