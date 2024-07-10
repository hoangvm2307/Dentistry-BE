using System.Linq.Expressions;
using DentistryBusinessObjects;
using DentistryRepositories.Extensions;

namespace DentistryRepositories
{
  public interface IClinicRepository
  {
    Task<PagedList<Clinic>> GetAllClinicsAsync(ClinicQueryParams queryParams);
    Task<PagedList<Clinic>> GetAllClinicsAsync(SearchParams searchParams);
 
    Task<Clinic> GetClinicByIdAsync(int id);
    Task AddClinicAsync(Clinic clinic);
    Task UpdateClinicAsync(Clinic clinic);
    Task DeleteClinicAsync(int id);
  }
}