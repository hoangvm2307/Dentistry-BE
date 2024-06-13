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
  }
}