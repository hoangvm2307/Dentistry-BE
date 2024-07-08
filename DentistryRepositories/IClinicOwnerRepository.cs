using System.Linq.Expressions;
using DentistryBusinessObjects;
using DentistryRepositories.Extensions;

namespace DentistryRepositories
{
  public interface IClinicOwnerRepository
  {
    Task<PagedList<ClinicOwner>> GetAllClinicOwnersAsync(ClinicOwnerQueryParams queryParams);
    Task<ClinicOwner> GetClinicOwnerByIdAsync(int id);
    Task AddClinicOwnerAsync(ClinicOwner clinicOwner);
    Task UpdateClinicOwnerAsync(ClinicOwner clinicOwner);
    Task DeleteClinicOwnerAsync(int id);
  }
}