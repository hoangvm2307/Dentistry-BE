using DentistryBusinessObjects;

namespace DentistryRepositories
{
  public interface IDentistRepository
  {
    Task<List<Dentist>> GetAllDentistsAsync();
    Task<Dentist> GetDentistByIdAsync(int id);
    Task AddDentistAsync(Dentist dentist);
    Task UpdateDentistAsync(Dentist dentist);
    Task DeleteDentistAsync(int id);
  }
}