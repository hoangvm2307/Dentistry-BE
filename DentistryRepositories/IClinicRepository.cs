using System.Linq.Expressions;
using DentistryBusinessObjects;

namespace DentistryRepositories
{
  public interface IClinicRepository
  {
    Task<IEnumerable<Clinic>> GetAllClinicsAsync();
    Task<Clinic> GetClinicByIdAsync(int id);
    Task AddClinicAsync(Clinic clinic);
    Task UpdateClinicAsync(Clinic clinic);
    Task DeleteClinicAsync(int id);
    Task<PaginatedList<Clinic>> GetPagedClinicsAsync(
            int pageIndex,
            int pageSize,
            Expression<Func<Clinic, bool>> filter,
            Func<IQueryable<Clinic>, IOrderedQueryable<Clinic>> orderBy);
  }
}