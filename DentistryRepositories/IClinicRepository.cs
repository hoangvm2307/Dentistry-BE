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
  }
}