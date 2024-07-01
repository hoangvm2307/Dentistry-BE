using System.Linq.Expressions;
using DentistryBusinessObjects;

namespace DentistryRepositories
{
  public interface IClinicOwnerRepository
  {
    Task<IEnumerable<ClinicOwner>> GetAllClinicOwnersAsync();
    Task<ClinicOwner> GetClinicOwnerByIdAsync(int id);
    Task AddClinicOwnerAsync(ClinicOwner clinicOwner);
    Task UpdateClinicOwnerAsync(ClinicOwner clinicOwner);
    Task DeleteClinicOwnerAsync(int id);
    Task<PaginatedList<ClinicOwner>> GetPagedClinicOwnersAsync(
            int pageIndex,
            int pageSize,
            Expression<Func<ClinicOwner, bool>> filter,
            Func<IQueryable<ClinicOwner>, IOrderedQueryable<ClinicOwner>> orderBy);
  }
}