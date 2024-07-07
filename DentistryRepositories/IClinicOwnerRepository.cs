using System.Linq.Expressions;
using DentistryBusinessObjects;
using DentistryRepositories.Extensions;

namespace DentistryRepositories
{
  public interface IClinicOwnerRepository
  {
    Task<PagedList<ClinicOwner>> GetAllClinicOwnersAsync(QueryableParam queryParams);
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